using UnityEngine;
    public class ExperienceManager : MonoBehaviour
    {
        public static ExperienceManager instance;

        public delegate void ExperienceChangeHandler(float amount);
        public event ExperienceChangeHandler OnExperienceChange;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        public void IncreaseExperience(float amount)
        {
            OnExperienceChange?.Invoke(amount);
        }
    }


