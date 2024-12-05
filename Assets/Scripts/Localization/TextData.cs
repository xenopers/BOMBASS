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
            {"uk", "�����" }
        }
        },

        { "hangar_key", new Dictionary<string, string>()
        {
            {"en", "Hangar" },
            {"uk", "�����" }
        }
        },

        { "settings_key", new Dictionary<string, string>()
        {
            {"en", "Settings" },
            {"uk", "�����" }
        }
        },


        { "coins_key", new Dictionary<string, string>()
        {
            {"en", "coins" },
            {"uk", "����" }
        }
        },

        { "pause_key", new Dictionary<string, string>()
        {
            {"en", "Pause" },
            {"uk", "�����" }
        }
        },

        { "collected_coins_key", new Dictionary<string, string>()
        {
            {"en", "Collected Coins" },
            {"uk", "ǳ���� ������" }
        }
        },

        { "game_score_key", new Dictionary<string, string>() 
        {
            {"en", "Game Score" },
            {"uk", "������� �������" }
        }
        },

        { "score_record_key", new Dictionary<string, string>()
        {
            {"en", "Best score: "},
            {"uk", "������ ���������: "}
        }
        },

        { "new_record_key", new Dictionary<string, string>()
        {
            {"en", "New\nrecord!" },
            {"uk", "�����\n������!" }
        }
        },

        { "0", new Dictionary<string, string>()
        {
            {"en", "0 coins" },
            {"uk", "0 ����" }
        }
        },


        { "10000", new Dictionary<string, string>()
        {
            {"en", "10.000 coins" },
            {"uk", "10.000 ����" }
        }
        },


        { "1000", new Dictionary<string, string>()
        {
            {"en", "1.000 coins" },
            {"uk", "1.000 ����" }
        }
        },


        { "su27_description_key", new Dictionary<string, string>()
        {
            {"en", "su27 description missing" },
            {"uk", "����� ��27 ����" }
        }
        },

        { "mig29_description_key", new Dictionary<string, string>()
        {
            {"en", "mig29 description missing" },
            {"uk", "����� mig29 ����" }
        }
        },

        { "su25_description_key", new Dictionary<string, string>()
        {
            {"en", "su25 description missing" },
            {"uk", "����� su25 ����" }
        }
        },

        { "f16_description_key", new Dictionary<string, string>()
        {
            {"en", "f16 description missing" },
            {"uk", "����� f16 ����" }
        }
        },


        { "selected_key", new Dictionary<string, string>()
        {
            {"en", "Selected" },
            {"uk", "�������" }
        }
        },

        { "select_jet_key", new Dictionary<string, string>()
        {
            {"en", "Select this jet" },
            {"uk", "������� ��� ����" }
        }
        },

        { "revive_key", new Dictionary<string, string>()
        {
            {"en", "Revive" },
            {"uk", "³���������" }
        }
        },

        { "gameover_key", new Dictionary<string, string>()
        {
            {"en", "Game Over" },
            {"uk", "��� ���������" }
        }
        },

        { "toangar_key", new Dictionary<string, string>()
        {
            {"en", "Back to hangar" },
            {"uk", "� �����" }
        }
        },

        { "doublecoin_key", new Dictionary<string, string>()
        {
            {"en", "Coin x2" },
            {"uk", "���� x2" }
        }
        },

        { "resume_key", new Dictionary<string, string>()
        {
            {"en", "Resume" },
            {"uk", "����������" }
        }
        },

        { "language_key", new Dictionary<string, string>()
        {
            {"en", "Language" },
            {"uk", "����" }
        } 
        },

        { "music_key", new Dictionary<string, string>()
        {
            {"en", "Music" },
            {"uk", "������" }
        }
        },

        { "sounds_key", new Dictionary<string, string>()
        {
            {"en", "Sounds" },
            {"uk", "�����" }
        }
        },

        { "restore_key", new Dictionary<string, string>()
        {
            {"en", "Restore purchases" },
            {"uk", "³������� �������" }
        }
        },

        { "restore_success_key", new Dictionary<string, string>()
        {
            {"en", "You restored purchases successfully!" },
            {"uk", "�� ������ �������� �������!" }
        }
        },

        { "restore_failed_key", new Dictionary<string, string>()
        {
            {"en", "Unable to restore purchases: " },
            {"uk", "�� ������� �������� �������: " }
        }
        },

        { "restart_game_key", new Dictionary<string, string>()
        {
            {"en", "Try again" },
            {"uk", "���������� �� ���" }
        }
        },

        { "ad_initialization_error_key", new Dictionary<string, string>()
        {
            {"en", "Ad viewing is currently unavailable" },
            {"uk", "�� ������ ������ �������� ������� �����������" }
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
