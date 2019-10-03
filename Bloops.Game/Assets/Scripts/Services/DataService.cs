using System;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public static class DataService
    {
        #region Public static methods

        public static T? GetValue<T>(string key) where T : struct
        {
            return PlayerPrefs.HasKey(key) ? GetValue<T>(key, default) : (T?)null;
        }

        public static T? GetUserValue<T>(string key) where T : struct
        {
            return GetValue<T>(GetUserKey(key));
        }

        public static T GetValue<T>(string key, T defaultValue)
        {
            if (typeof(T) == typeof(int) && defaultValue is int defaultIntValue)
            {
                return ChangeType<int, T>(PlayerPrefs.GetInt(key, defaultIntValue));
            }
            else if (typeof(T) == typeof(float) && defaultValue is float defaultFloatValue)
            {
                return ChangeType<float, T>(PlayerPrefs.GetFloat(key, defaultFloatValue));
            }
            else if (typeof(T) == typeof(string) && defaultValue is string defaultStringValue)
            {
                return ChangeType<string, T>(PlayerPrefs.GetString(key, defaultStringValue));
            }
            else
            {
                throw new Exception();
            }
        }

        public static T GetUserValue<T>(string key, T defaultValue)
        {
            return GetValue(GetUserKey(key), defaultValue);
        }

        public static void SetValue<T>(string key, T value)
        {
            if (value is int intValue)
            {
                PlayerPrefs.SetInt(key, intValue);
            }
            else if (value is float floatValue)
            {
                PlayerPrefs.SetFloat(key, floatValue);
            }
            else if (value is string stringValue)
            {
                PlayerPrefs.SetString(key, stringValue);
            }
            else
            {
                throw new Exception();
            }
        }

        public static void SetUserValue<T>(string key, T value)
        {
            SetValue(GetUserKey(key), value);
        }

        public static void SetValueAndSave<T>(string key, T value)
        {
            SetValue(key, value);
            Save();
        }

        public static void SetUserValueAndSave<T>(string key, T value)
        {
            SetValue<T>(GetUserKey(key), value);
            Save();
        }

        public static void DeleteValue(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public static void DeleteUserValue(string key)
        {
            DeleteValue(GetUserKey(key));
        }

        public static void DeleteValueAndSave(string key)
        {
            DeleteValue(key);
            Save();
        }

        public static void DeleteUserValueAndSave(string key)
        {
            DeleteUserValue(key);
            Save();
        }

        public static void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }

        public static void Save()
        {
            PlayerPrefs.Save();
        }

        #endregion

        #region Private static methods

        private static string GetUserKey(string key)
        {
            return $"U{Social.localUser.id}_{key}";
        }

        private static TOut ChangeType<TIn, TOut>(TIn value)
        {
            return (TOut)Convert.ChangeType(value, typeof(TOut));
        }

        #endregion
    }
}
