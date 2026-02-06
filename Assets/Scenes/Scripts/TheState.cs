using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameEvent
{
    public string type;
    public string text;
    public EventResult result;
    [SerializeReference] public List<GameEvent> confirm;
    [SerializeReference] public List<GameEvent> decline;
}

[System.Serializable]
public class EventResult
{
    public int health;
    public int stamina;
    public int intellect;
    public int money;
    public float timeSkip; // hours to skip
}


public class TheState : MonoBehaviour
{

    private static List<GameEvent> allEvents = new List<GameEvent> {
    // Hot dog mascot chain
    new GameEvent {
      type = "choice",
      text = "A guy dressed as a hot dog hands you a flyer. He insists you ARE the chosen one. Accept your destiny?",
      confirm = new List < GameEvent > {
        new GameEvent {
          type = "choice",
          text = "He takes you to his hot dog stand. You're now the official 'Hot Dog Mascot'. This is your life. Embrace it?",
          confirm = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "You dance in a hot dog costume for 2 hours. Kids love you. You make $45 and question your choices.",
              result = new EventResult {
                money = 45,
                health = -2,
                stamina = -3,
                intellect = -2,
                timeSkip = 2
              }
            }
          },
          decline = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "You refuse. He sadly eats a hot dog alone. You feel guilty and buy one from him anyway.",
              result = new EventResult {
                money = -8,
                health = 1,
                intellect = 1,
                timeSkip = 0.25f
              }
            }
          }
        }
      },
      decline = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "He whispers 'You'll regret this' and moonwalks away. You find $12 on the ground. Maybe you ARE chosen?",
          result = new EventResult {
            money = 12,
            intellect = 1,
            health = 1
          }
        }
      }
    },

    // Wedding photobomb
    new GameEvent {
      type = "response",
      text = "You accidentally photobomb a wedding photo. The couple thanks you and insists you're good luck. They give you cake.",
      result = new EventResult {
        health = 3,
        stamina = 2,
        timeSkip = 0.5f
      }
    },

    // Parkour challenge
    new GameEvent {
      type = "choice",
      text = "A parkour expert challenges you to jump over a bench. You've never done parkour. Try anyway?",
      confirm = new List < GameEvent > {
        new GameEvent {
          type = "choice",
          text = "You jump! You make it! Barely. He offers to teach you more moves. Spend 2 hours training?",
          confirm = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "You learn basic parkour! You're exhausted but feel like an action hero. You can now jump over small things.",
              result = new EventResult {
                stamina = -3,
                health = 2,
                intellect = 1,
                timeSkip = 2
              }
            }
          },
          decline = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "You politely decline. He respects boundaries. Gives you his energy drink. It tastes like regret and chemicals.",
              result = new EventResult {
                health = -1,
                stamina = 2,
                timeSkip = 0.25f
              }
            }
          }
        }
      },
      decline = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "You wisely walk around the bench. He calls you 'smart but boring'. You can live with that.",
          result = new EventResult {
            intellect = 2,
            health = 0
          }
        }
      }
    },

    // Rubber duck
    new GameEvent {
      type = "choice",
      text = "You find a rubber duck in a puddle. It squeaks when you step on it. Take it home?",
      confirm = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "You adopt the duck. It brings you joy. A kid offers you $15 for it but you refuse. Priceless friendship.",
          result = new EventResult {
            health = 3,
            intellect = 1,
            money = 0
          }
        }
      },
      decline = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "You leave it. A duck (real) comes and claims the rubber duck. Nature is healing. You feel philosophical.",
          result = new EventResult {
            intellect = 2,
            health = 1,
            timeSkip = 0.25f
          }
        }
      }
    },

    // Uber mixup
    new GameEvent {
      type = "response",
      text = "Someone mistakes you for their Uber driver. You're too awkward to correct them. They get out 10 minutes later confused.",
      result = new EventResult {
        intellect = -2,
        stamina = -1,
        timeSkip = 0.75f
      }
    },

    // Balloon with money (nested deep)
    new GameEvent {
      type = "choice",
      text = "A kid's balloon floats toward you. It has $5 taped to it with a note: 'Finders keepers'. Keep it?",
      confirm = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "You keep the $5. The balloon pops immediately. You feel like you cheated a child but money is money.",
          result = new EventResult {
            money = 5,
            intellect = -1,
            health = -1
          }
        }
      },
      decline = new List < GameEvent > {
        new GameEvent {
          type = "choice",
          text = "You try to find the kid. You find them crying. Return the balloon?",
          confirm = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "Kid stops crying. Parents give you $20 as thanks. Good karma is real.",
              result = new EventResult {
                money = 20,
                health = 2,
                intellect = 2,
                timeSkip = 0.5f
              }
            }
          },
          decline = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "You panic and run away with the balloon. You're a balloon thief now. Guilt consumes you.",
              result = new EventResult {
                money = 5,
                health = -2,
                intellect = -2,
                stamina = -2,
                timeSkip = 0.5f
              }
            }
          }
        }
      }
    },

    // Parallel parking
    new GameEvent {
      type = "choice",
      text = "You see someone struggling to parallel park. They've been trying for 5 minutes. Offer to help?",
      confirm = new List < GameEvent > {
        new GameEvent {
          type = "choice",
          text = "You guide them in. They hit the curb. They blame you. Apologize?",
          confirm = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "You apologize profusely. They calm down and actually thank you. They give you $10 for trying.",
              result = new EventResult {
                money = 10,
                health = 1,
                timeSkip = 0.5f
              }
            }
          },
          decline = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "You argue it wasn't your fault. They drive away angry. A witness gives you $5 for entertainment.",
              result = new EventResult {
                money = 5,
                intellect = -1,
                health = -1,
                timeSkip = 0.5f
              }
            }
          }
        }
      },
      decline = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "You watch them eventually succeed. They wave at you happily. You feel like you were part of something.",
          result = new EventResult {
            health = 2,
            timeSkip = 0.75f
          }
        }
      }
    },

    // Bird poop luck
    new GameEvent {
      type = "response",
      text = "A bird poops on your shoulder. An old lady says it's good luck and hands you a lottery scratch card. You win $8!",
      result = new EventResult {
        money = 8,
        health = -1,
        intellect = 1
      }
    },

    // Chess grandma
    new GameEvent {
      type = "choice",
      text = "You find a chess set in the park. A grandma challenges you to a game. Accept?",
      confirm = new List < GameEvent > {
        new GameEvent {
          type = "choice",
          text = "She's destroying you. Every move is calculated. You're losing badly. Forfeit?",
          confirm = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "You forfeit. She teaches you chess strategies for an hour. Your brain hurts but you're smarter now.",
              result = new EventResult {
                intellect = 3,
                stamina = -2,
                timeSkip = 1.5f
              }
            }
          },
          decline = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "You keep playing. You lose spectacularly. She laughs kindly and buys you coffee. Worth it.",
              result = new EventResult {
                intellect = 2,
                health = 2,
                stamina = -1,
                timeSkip = 1
              }
            }
          }
        }
      },
      decline = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "She looks disappointed. You feel bad. You watch her play against someone else. She wins in 4 moves. Terrifying.",
          result = new EventResult {
            intellect = 1,
            health = -1,
            timeSkip = 0.5f
          }
        }
      }
    },

    // Mega burrito
    new GameEvent {
      type = "choice",
      text = "A food truck has a challenge: eat a mega burrito in 10 minutes, win $50. Try it?",
      confirm = new List < GameEvent > {
        new GameEvent {
          type = "choice",
          text = "It's HUGE. You're halfway through and dying. Your stomach hurts. Push through?",
          confirm = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "YOU DID IT! You win $50 but can't move for an hour. Totally worth it. Maybe.",
              result = new EventResult {
                money = 50,
                health = -3,
                stamina = -3,
                timeSkip = 1.5f
              }
            }
          },
          decline = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "You tap out. You still have to pay $18 for the burrito. Expensive failure.",
              result = new EventResult {
                money = -18,
                health = -2,
                stamina = -1,
                timeSkip = 0.5f
              }
            }
          }
        }
      },
      decline = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "You order a normal taco instead. It's delicious and reasonable. Someone else attempts the challenge and vomits.",
          result = new EventResult {
            money = -6,
            health = 2,
            intellect = 2,
            timeSkip = 0.25f
          }
        }
      }
    },

    // Shoelace $10
    new GameEvent {
      type = "response",
      text = "Your shoelace comes untied. You tie it and find a $10 bill stuck to your shoe. Lucky day!",
      result = new EventResult {
        money = 10,
        health = 1
      }
    },

    // Street performer
    new GameEvent {
      type = "choice",
      text = "A street performer does a backflip and lands it perfectly. He asks for tips. Give him $5?",
      confirm = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "He's so grateful he teaches you to juggle. You drop all the balls. It's harder than it looks.",
          result = new EventResult {
            money = -5,
            intellect = 1,
            health = 1,
            timeSkip = 0.5f
          }
        }
      },
      decline = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "You clap enthusiastically but don't tip. He looks sad. You feel like a villain.",
          result = new EventResult {
            health = -2
          }
        }
      }
    },

    // Free hugs
    new GameEvent {
      type = "choice",
      text = "You see a 'Free Hugs' sign. The person looks lonely. Give them a hug?",
      confirm = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "Best hug ever. They say you made their day. You made YOUR day too. Wholesome +3.",
          result = new EventResult {
            health = 3,
            intellect = 0,
            stamina = 1
          }
        }
      },
      decline = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "You wave instead. They wave back. It's awkward but sweet. Connection +1.",
          result = new EventResult {
            health = 1,
            intellect = 1
          }
        }
      }
    },

    // Puzzle piece
    new GameEvent {
      type = "response",
      text = "You find a puzzle piece on the ground. Just one piece. You keep it. You don't know why. Chaos +1.",
      result = new EventResult {
        intellect = -1,
        health = 1
      }
    },

    // Dog park volunteer
    new GameEvent {
      type = "choice",
      text = "A dog park nearby has a sign: 'Volunteers needed to pet dogs for 1 hour'. Volunteer?",
      confirm = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "BEST. HOUR. EVER. You pet 47 dogs. You smell like dog. You're covered in fur. You're happy.",
          result = new EventResult {
            health = 3,
            stamina = -2,
            intellect = 1,
            timeSkip = 1
          }
        }
      },
      decline = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "You walk away. A puppy escapes and runs to you anyway. You pet it. You were chosen.",
          result = new EventResult {
            health = 2,
            intellect = 0,
            timeSkip = 0.25f
          }
        }
      }
    },

    // Dropped groceries
    new GameEvent {
      type = "choice",
      text = "Someone drops their groceries. Cans roll everywhere. Help them?",
      confirm = new List < GameEvent > {
        new GameEvent {
          type = "choice",
          text = "You help gather cans. One rolls into traffic. Chase it?",
          confirm = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "You risk your life for a can of beans. Cars honk. You retrieve it. They give you $15 and call you 'brave but stupid'.",
              result = new EventResult {
                money = 15,
                health = -2,
                stamina = -2,
                intellect = -2,
                timeSkip = 0.5f
              }
            }
          },
          decline = new List < GameEvent > {
            new GameEvent {
              type = "response",
              text = "You let it go. It's just beans. They appreciate your help with everything else. They give you $8.",
              result = new EventResult {
                money = 8,
                health = 1,
                intellect = 2,
                timeSkip = 0.25f
              }
            }
          }
        }
      },
      decline = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "You pretend not to see. Someone else helps. You feel guilty watching. Karma notes this.",
          result = new EventResult {
            health = -1,
            intellect = -1,
            timeSkip = 0.25f
          }
        }
      }
    },

    // Ice cream truck chase
    new GameEvent {
      type = "response",
      text = "You hear ice cream truck music. You chase it for 3 blocks. It drives away. You're winded but determined.",
      result = new EventResult {
        stamina = -3,
        health = -1,
        intellect = -1,
        timeSkip = 0.5f
      }
    },

    // Tourist photo
    new GameEvent {
      type = "choice",
      text = "A tourist asks you to take their photo. You notice their backpack is open. Tell them?",
      confirm = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "You tell them. They're so grateful! Their wallet almost fell out. They give you $25 as thanks.",
          result = new EventResult {
            money = 25,
            health = 2,
            intellect = 2,
            timeSkip = 0.25f
          }
        }
      },
      decline = new List < GameEvent > {
        new GameEvent {
          type = "response",
          text = "You just take the photo. Their wallet falls out after they leave. You run after them. Cardio +1.",
          result = new EventResult {
            stamina = -1,
            health = 1,
            intellect = -1,
            timeSkip = 0.5f
          }
        }
      }
    }
  };
    public static TheState Instance { get; private set; }

    public GameObject eventpoup;
    public GameObject responcepopup;

    [SerializeField] private RectTransform healthBarRect;
    [SerializeField] private RectTransform staminaBarRect;
    [SerializeField] private RectTransform intellectBarRect;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI EventText;
    [SerializeField] private TextMeshProUGUI timetext;
    [SerializeField] private TextMeshProUGUI responseText;

    [SerializeField] private UnityEngine.UI.Image nightOverlay;

    [SerializeField] private float gameDayDurationMinutes = 3f;
    [SerializeField] private float minEventInterval = 30f;
    [SerializeField] private float maxEventInterval = 90f;

    private const float BAR_WIDTH = 300f;
    private const float BAR_HEIGHT = 30f;
    private const float MIN_DAY_DURATION = 2f;
    private const float MAX_DAY_DURATION = 5f;

    private float nextEventTime;
    private bool isEventActive = false;
    private GameEvent currentEvent;

    //private void Awake()
    //{
    //    // Singleton pattern
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else if (Instance != this)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //}

    void Start()
    {
        SetMaxHealth(GlobalVars.MaxHealth);
        SetMaxStamina(GlobalVars.MaxStamina);
        SetMaxIntellect(GlobalVars.MaxIntellect);
        UpdateMoneyText();
        UpdateTimeText();
        ScheduleNextEvent();
        StartCoroutine(GameTimeLoop());
    }

    private void UpdateNightOverlay()
    {
        if (nightOverlay != null)
        {
            float alpha = CalculateNightAlpha(GlobalVars.GameTimeHours);
            Color overlayColor = nightOverlay.color;
            overlayColor.a = alpha / 255f; // Convert 0-255 to 0-1 range
            nightOverlay.color = overlayColor;
        }
    }

    private float CalculateNightAlpha(float hours)
    {
        // Peak day (noon = 12:00): alpha = 20
        // Peak night (midnight = 0:00 or 24:00): alpha = 240

        if (hours >= 6f && hours <= 18f)
        {
            // Daytime (6 AM to 6 PM)
            // At 12:00 (noon), alpha should be 20 (minimum)
            float noonDistance = Mathf.Abs(hours - 12f); // 0 at noon, 6 at 6 AM/PM
            return Mathf.Lerp(20f, 150f, noonDistance / 6f);
        }
        else
        {
            // Nighttime (6 PM to 6 AM)
            float nightHours = hours >= 18f ? hours - 18f : hours + 6f; // 0 at 6 PM, 6 at midnight, 12 at 6 AM

            if (nightHours <= 6f)
            {
                // 6 PM to midnight: darkening
                return Mathf.Lerp(150f, 240f, nightHours / 6f);
            }
            else
            {
                // Midnight to 6 AM: lightening
                return Mathf.Lerp(240f, 150f, (nightHours - 6f) / 6f);
            }
        }
    }

    private IEnumerator GameTimeLoop()
    {
        while (true)
        {
            float secondsPerGameHour = (gameDayDurationMinutes * 60f) / 24f;
            yield return new WaitForSeconds(secondsPerGameHour);

            if (!isEventActive)
            {
                GlobalVars.GameTimeHours += 1f;

                if (GlobalVars.GameTimeHours >= 24f)
                {
                    GlobalVars.GameTimeHours = 0f;
                }

                UpdateTimeText();
                UpdateNightOverlay();

                // Check for sleep penalty at 23:00
                if (GlobalVars.GameTimeHours >= 23f && !GlobalVars.HasSlept)
                {
                    TriggerSleepPenalty();
                    GlobalVars.HasSlept = true;
                }

                // Reset HasSlept at midnight (0:00-1:00)
                if (GlobalVars.GameTimeHours >= 0f && GlobalVars.GameTimeHours < 1f)
                {
                    GlobalVars.HasSlept = false;
                }
            }
        }
    }

    private void ScheduleNextEvent()
    {
        nextEventTime = Time.time + Random.Range(minEventInterval, maxEventInterval);
    }

    void LateUpdate()
    {
        if (!isEventActive && Time.time >= nextEventTime && allEvents.Count > 0)
        {
            TriggerRandomEvent();
        }
    }

    private void TriggerRandomEvent()
    {
        int randomIndex = Random.Range(0, allEvents.Count);
        currentEvent = allEvents[randomIndex];
        PopupEvent(currentEvent);
    }

    private void TriggerSleepPenalty()
    {
        GameEvent sleepEvent = new GameEvent
        {
            type = "choice",
            text = "It's 23:00 and you haven't slept. Go to bed now or pull an all-nighter?",
            confirm = new List<GameEvent> {
                new GameEvent {
                    type = "response",
                    text = "You went to bed. You wake up refreshed at 6:00 AM.",
                    result = new EventResult {
                        health = 10,
                        stamina = GlobalVars.MaxStamina - GlobalVars.Stamina,
                        timeSkip = 7f
                    }
                }
            },
            decline = new List<GameEvent> {
                new GameEvent {
                    type = "response",
                    text = "You stayed awake all night. You feel exhausted and sick.",
                    result = new EventResult {
                        health = -20,
                        stamina = -30,
                        intellect = -10
                    }
                }
            }
        };

        currentEvent = sleepEvent;
        PopupEvent(currentEvent);
    }

    public void PopupEvent(GameEvent gameEvent)
    {
        isEventActive = true;
        Time.timeScale = 0f;

        if (eventpoup != null)
        {
            eventpoup.SetActive(true);

            if (EventText != null)
            {
                EventText.text = gameEvent.text;
            }
        }
    }

    public void OnEventConfirm()
    {
        if (currentEvent != null && currentEvent.confirm != null && currentEvent.confirm.Count > 0)
        {
            GameEvent nextEvent = currentEvent.confirm[0];

            if (nextEvent.type == "response")
            {
                ShowResponse(nextEvent);
            }
            else if (nextEvent.type == "choice")
            {
                currentEvent = nextEvent;
                PopupEvent(currentEvent);
            }
        }
        else
        {
            CloseEvent();
        }
    }

    public void OnEventDecline()
    {
        if (currentEvent != null && currentEvent.decline != null && currentEvent.decline.Count > 0)
        {
            GameEvent nextEvent = currentEvent.decline[0];

            if (nextEvent.type == "response")
            {
                ShowResponse(nextEvent);
            }
            else if (nextEvent.type == "choice")
            {
                currentEvent = nextEvent;
                PopupEvent(currentEvent);
            }
        }
        else
        {
            CloseEvent();
        }
    }

    private void ShowResponse(GameEvent responseEvent)
    {
        if (eventpoup != null)
        {
            eventpoup.SetActive(false);
        }

        if (responcepopup != null)
        {
            responcepopup.SetActive(true);

            if (responseText != null)
            {
                responseText.text = responseEvent.text;
            }
        }

        if (responseEvent.result != null)
        {
            ApplyEventResult(responseEvent.result);
        }
    }

    public void CloseResponse()
    {
        if (responcepopup != null)
        {
            responcepopup.SetActive(false);
        }

        CloseEvent();
    }

    private void CloseEvent()
    {
        if (eventpoup != null)
        {
            eventpoup.SetActive(false);
        }

        isEventActive = false;
        Time.timeScale = 1f;
        currentEvent = null;
        ScheduleNextEvent();
    }

    private void ApplyEventResult(EventResult result)
    {
        if (result.health != 0) SetHealth(result.health);
        if (result.stamina != 0) SetStamina(result.stamina);
        if (result.intellect != 0) SetIntellect(result.intellect);
        if (result.money != 0) SetMoney(GlobalVars.Money + result.money);

        if (result.timeSkip > 0)
        {
            GlobalVars.GameTimeHours += result.timeSkip;
            if (GlobalVars.GameTimeHours >= 24f) GlobalVars.GameTimeHours -= 24f;
            UpdateTimeText();
        }
    }

    public void SetHealth(int healthChange)
    {
        GlobalVars.Health += healthChange;
        GlobalVars.Health = Mathf.Clamp(GlobalVars.Health, 0, GlobalVars.MaxHealth);
        UpdateBar(healthBarRect, GlobalVars.Health, GlobalVars.MaxHealth);

        if (GlobalVars.Health <= 0)
        {
            GameOver();
        }
    }

    public int GetMaxHealth()
    {
        return GlobalVars.MaxHealth;
    }

    public void SetMaxHealth(int newMaxHealth)
    {
        GlobalVars.MaxHealth = newMaxHealth;
        healthBarRect.sizeDelta = new Vector2(BAR_WIDTH, BAR_HEIGHT);
        GlobalVars.Health = Mathf.Clamp(GlobalVars.Health, 0, GlobalVars.MaxHealth);
        UpdateBar(healthBarRect, GlobalVars.Health, GlobalVars.MaxHealth);
    }

    public void SetStamina(int staminaChange)
    {
        GlobalVars.Stamina += staminaChange;
        GlobalVars.Stamina = Mathf.Clamp(GlobalVars.Stamina, 0, GlobalVars.MaxStamina);
        UpdateBar(staminaBarRect, GlobalVars.Stamina, GlobalVars.MaxStamina);

        // Adjust game day duration based on stamina
        float staminaRatio = (float)GlobalVars.Stamina / GlobalVars.MaxStamina;
        gameDayDurationMinutes = Mathf.Lerp(MAX_DAY_DURATION, MIN_DAY_DURATION, staminaRatio);
    }

    public void SetMaxStamina(int newMaxStamina)
    {
        GlobalVars.MaxStamina = newMaxStamina;
        staminaBarRect.sizeDelta = new Vector2(BAR_WIDTH, BAR_HEIGHT);
        GlobalVars.Stamina = Mathf.Clamp(GlobalVars.Stamina, 0, GlobalVars.MaxStamina);
        UpdateBar(staminaBarRect, GlobalVars.Stamina, GlobalVars.MaxStamina);
    }

    public void SetIntellect(int intellectChange)
    {
        GlobalVars.Intellect += intellectChange;
        GlobalVars.Intellect = Mathf.Clamp(GlobalVars.Intellect, 0, GlobalVars.MaxIntellect);
        UpdateBar(intellectBarRect, GlobalVars.Intellect, GlobalVars.MaxIntellect);
    }

    public void SetMaxIntellect(int newMaxIntellect)
    {
        GlobalVars.MaxIntellect = newMaxIntellect;
        intellectBarRect.sizeDelta = new Vector2(BAR_WIDTH, BAR_HEIGHT);
        GlobalVars.Intellect = Mathf.Clamp(GlobalVars.Intellect, 0, GlobalVars.MaxIntellect);
        UpdateBar(intellectBarRect, GlobalVars.Intellect, GlobalVars.MaxIntellect);
    }

    public void SetMoney(int newMoney)
    {
        GlobalVars.Money = newMoney;
        UpdateMoneyText();
    }

    private void UpdateBar(RectTransform barRect, int current, int max)
    {
        if (barRect != null && max > 0)
        {
            float fillRatio = (float)current / max;
            float newWidth = fillRatio * BAR_WIDTH;
            barRect.sizeDelta = new Vector2(newWidth, BAR_HEIGHT);
        }
    }

    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = "$" + GlobalVars.Money.ToString();
        }
    }

    private void UpdateTimeText()
    {
        if (timetext != null)
        {
            int hours = Mathf.FloorToInt(GlobalVars.GameTimeHours);
            int minutes = Mathf.FloorToInt((GlobalVars.GameTimeHours - hours) * 60f);
            timetext.text = string.Format("{0:00}:{1:00}", hours, minutes);
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over - Health reached 0");
        SceneManager.LoadScene(3);
    }
}