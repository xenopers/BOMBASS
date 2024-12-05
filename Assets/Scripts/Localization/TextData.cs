using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class TextData
{
    public static string CURRENT_LANGUAGE = PlayerPrefs.GetString("language");

    public static Dictionary<string, Dictionary<string, string>> LOCALIZATION =
        new Dictionary<string, Dictionary<string, string>>()
    {
        { "play_key", new Dictionary<string, string>()
        {
            {"en", "Play" },
            {"uk", "Грати" }
        }
        },

        { "hangar_key", new Dictionary<string, string>()
        {
            {"en", "Hangar" },
            {"uk", "Ангар" }
        }
        },

        { "settings_key", new Dictionary<string, string>()
        {
            {"en", "Settings" },
            {"uk", "Опції" }
        }
        },


        { "coins_key", new Dictionary<string, string>()
        {
            {"en", "coins" },
            {"uk", "коїнів" }
        }
        },

        { "pause_key", new Dictionary<string, string>()
        {
            {"en", "Pause" },
            {"uk", "Пауза" }
        }
        },

        { "collected_coins_key", new Dictionary<string, string>()
        {
            {"en", "Collected Coins" },
            {"uk", "Зібрані монети" }
        }
        },

        { "game_score_key", new Dictionary<string, string>() 
        {
            {"en", "Game Score" },
            {"uk", "Ігровий рахунок" }
        }
        },

        { "score_record_key", new Dictionary<string, string>()
        {
            {"en", "Best score: "},
            {"uk", "Кращий результат: "}
        }
        },

        { "new_record_key", new Dictionary<string, string>()
        {
            {"en", "New\nrecord!" },
            {"uk", "Новий\nрекорд!" }
        }
        },

        { "0", new Dictionary<string, string>()
        {
            {"en", "0 coins" },
            {"uk", "0 коїнів" }
        }
        },


        { "10000", new Dictionary<string, string>()
        {
            {"en", "10.000 coins" },
            {"uk", "10.000 коїнів" }
        }
        },


        { "1000", new Dictionary<string, string>()
        {
            {"en", "1.000 coins" },
            {"uk", "1.000 коїнів" }
        }
        },


        { "su27_description_key", new Dictionary<string, string>()
        {
            {"en", "su27 description missing" },
            {"uk", "опису су27 немає" }
        }
        },

        { "mig29_description_key", new Dictionary<string, string>()
        {
            {"en", "mig29 description missing" },
            {"uk", "опису mig29 немає" }
        }
        },

        { "su25_description_key", new Dictionary<string, string>()
        {
            {"en", "su25 description missing" },
            {"uk", "опису su25 немає" }
        }
        },

        { "f16_description_key", new Dictionary<string, string>()
        {
            {"en", "f16 description missing" },
            {"uk", "опису f16 немає" }
        }
        },


        { "selected_key", new Dictionary<string, string>()
        {
            {"en", "Selected" },
            {"uk", "Вибрано" }
        }
        },

        { "select_jet_key", new Dictionary<string, string>()
        {
            {"en", "Select this jet" },
            {"uk", "Вибрати цей літак" }
        }
        },

        { "revive_key", new Dictionary<string, string>()
        {
            {"en", "Revive" },
            {"uk", "Відродитися" }
        }
        },

        { "gameover_key", new Dictionary<string, string>()
        {
            {"en", "Game Over" },
            {"uk", "Гра завершена" }
        }
        },

        { "toangar_key", new Dictionary<string, string>()
        {
            {"en", "Back to hangar" },
            {"uk", "В ангар" }
        }
        },

        { "doublecoin_key", new Dictionary<string, string>()
        {
            {"en", "Coin x2" },
            {"uk", "Коїни x2" }
        }
        },

        { "resume_key", new Dictionary<string, string>()
        {
            {"en", "Resume" },
            {"uk", "Продовжити" }
        }
        },

        { "language_key", new Dictionary<string, string>()
        {
            {"en", "Language" },
            {"uk", "Мова" }
        } 
        },

        { "music_key", new Dictionary<string, string>()
        {
            {"en", "Music" },
            {"uk", "Музика" }
        }
        },

        { "sounds_key", new Dictionary<string, string>()
        {
            {"en", "Sounds" },
            {"uk", "Звуки" }
        }
        },

        { "restore_key", new Dictionary<string, string>()
        {
            {"en", "Restore purchases" },
            {"uk", "Відновити покупки" }
        }
        },

        { "restore_success_key", new Dictionary<string, string>()
        {
            {"en", "You restored purchases successfully!" },
            {"uk", "Ви успішно відновили покупки!" }
        }
        },

        { "restore_failed_key", new Dictionary<string, string>()
        {
            {"en", "Unable to restore purchases: " },
            {"uk", "Не вдалося відновити покупки: " }
        }
        },

        { "restart_game_key", new Dictionary<string, string>()
        {
            {"en", "Try again" },
            {"uk", "Спробувати ще раз" }
        }
        },

        { "ad_initialization_error_key", new Dictionary<string, string>()
        {
            {"en", "Ad viewing is currently unavailable" },
            {"uk", "На данний момент перегляд реклами недоступний" }
        }
        },

    };

    /*private static UnityEvent _OnLanguageChanged;

    public static UnityEvent OnLanguageChanged
    {
        get
        {
            if (_OnLanguageChanged != null)
                _OnLanguageChanged = new UnityEvent();
            return _OnLanguageChanged;
        }
    }*/

}
