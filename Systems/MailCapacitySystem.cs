// Systems/MailCapacitySystem.cs
// One-shot system: applies van + facility capacity multipliers when settings change.

namespace MagicMail
{
    using Game;
    using Game.Prefabs;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Updates post van and postal facility capacities when MagicMail sliders change.
    /// Driven by Setting.Apply() and then disables itself again.
    /// </summary>
    public partial class MailCapacitySystem : GameSystemBase
    {
        // Last applied percentages; 100 = vanilla.
        private int m_LastVanMailPercent = 100;
        private int m_LastVanFleetPercent = 100;
        private int m_LastTruckFleetPercent = 100;
        private int m_LastSortingSpeedPercent = 100;
        private int m_LastSortingStoragePercent = 100;

        protected override void OnCreate()
        {
            base.OnCreate();

            // Only run if we actually have postal prefabs.
            RequireForUpdate<PostFacilityData>();
            RequireForUpdate<PostVanData>();

            // Enabled only when Setting.Apply() asks for it.
            Enabled = false;
        }

        /// <summary>
        /// Run every tick while enabled; we disable ourselves after applying changes.
        /// </summary>
        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            return 1;
        }

        protected override void OnUpdate()
        {
            Setting? settings = Mod.Settings;
            if (settings == null)
            {
                Enabled = false;
                return;
            }

            bool changeCapacity = settings.ChangeCapacity;

            // Clamp sliders to safe ranges.
            int newVanMailPercent =
                math.clamp(settings.PostVanMailLoadPercentage, 100, 500);
            int newVanFleetPercent =
                math.clamp(settings.PostVanFleetSizePercentage, 50, 300);
            int newTruckFleetPercent =
                math.clamp(settings.TruckCapacityPercentage, 50, 300);
            int newSortingSpeedPercent =
                math.clamp(settings.PSF_SortingSpeedPercentage, 50, 500);
            int newSortingStoragePercent =
                math.clamp(settings.PSF_StorageCapacityPercentage, 50, 300);

            // When ChangeCapacity is OFF, we logically force everything back to 100%.
            if (!changeCapacity)
            {
                newVanMailPercent = 100;
                newVanFleetPercent = 100;
                newTruckFleetPercent = 100;
                newSortingSpeedPercent = 100;
                newSortingStoragePercent = 100;
            }

            bool vansChanged = newVanMailPercent != m_LastVanMailPercent;
            bool facilityChanged =
                newVanFleetPercent != m_LastVanFleetPercent ||
                newTruckFleetPercent != m_LastTruckFleetPercent ||
                newSortingSpeedPercent != m_LastSortingSpeedPercent ||
                newSortingStoragePercent != m_LastSortingStoragePercent;

            if (!vansChanged && !facilityChanged)
            {
                // Nothing to do; go back to sleep.
                Enabled = false;
                return;
            }

            // --- Post van mail capacity (payload) ---

            if (vansChanged)
            {
                float mailScale =
                    newVanMailPercent / (float)m_LastVanMailPercent;

                foreach (RefRW<PostVanData> van in SystemAPI.Query<RefRW<PostVanData>>())
                {
                    ref PostVanData vanData = ref van.ValueRW;

                    int newCapacity = (int)math.round(vanData.m_MailCapacity * mailScale);
                    vanData.m_MailCapacity = math.max(1, newCapacity);
                }

                m_LastVanMailPercent = newVanMailPercent;
            }

            // --- Facility van/truck/sorting/storage ---

            if (facilityChanged)
            {
                float vanFleetScale =
                    newVanFleetPercent / (float)m_LastVanFleetPercent;
                float truckFleetScale =
                    newTruckFleetPercent / (float)m_LastTruckFleetPercent;
                float sortingSpeedScale =
                    newSortingSpeedPercent / (float)m_LastSortingSpeedPercent;
                float sortingStorageScale =
                    newSortingStoragePercent / (float)m_LastSortingStoragePercent;

                foreach (RefRW<PostFacilityData> facility in SystemAPI.Query<RefRW<PostFacilityData>>())
                {
                    ref PostFacilityData data = ref facility.ValueRW;

                    if (data.m_PostVanCapacity > 0 && vanFleetScale != 1f)
                    {
                        data.m_PostVanCapacity =
                            math.max(0, (int)math.round(data.m_PostVanCapacity * vanFleetScale));
                    }

                    if (data.m_PostTruckCapacity > 0 && truckFleetScale != 1f)
                    {
                        data.m_PostTruckCapacity =
                            math.max(0, (int)math.round(data.m_PostTruckCapacity * truckFleetScale));
                    }

                    if (data.m_SortingRate > 0 && sortingSpeedScale != 1f)
                    {
                        data.m_SortingRate =
                            math.max(1, (int)math.round(data.m_SortingRate * sortingSpeedScale));
                    }

                    if (data.m_MailCapacity > 0 && sortingStorageScale != 1f)
                    {
                        data.m_MailCapacity =
                            math.max(1, (int)math.round(data.m_MailCapacity * sortingStorageScale));
                    }
                }

                m_LastVanFleetPercent = newVanFleetPercent;
                m_LastTruckFleetPercent = newTruckFleetPercent;
                m_LastSortingSpeedPercent = newSortingSpeedPercent;
                m_LastSortingStoragePercent = newSortingStoragePercent;
            }

            // Back to disabled until the next Apply() call.
            Enabled = false;
        }
    }
}
