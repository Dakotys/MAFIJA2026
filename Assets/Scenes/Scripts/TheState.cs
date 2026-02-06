using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    // Hardcoded initial values
    private int Health = 100,
    MaxHealth = 100;
    private int Stamina = 100,
    MaxStamina = 100;
    private int Intellect = 50,
    MaxIntellect = 100;
    private int Money = 50;

    public static bool HasSlept = false;

    public GameObject eventpoup;
    public GameObject responcepopup;

    [SerializeField] private RectTransform healthBarRect;
    [SerializeField] private RectTransform staminaBarRect;
    [SerializeField] private RectTransform intellectBarRect;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI EventText;
    [SerializeField] private TextMeshProUGUI timetext;
    [SerializeField] private TextMeshProUGUI responseText;

    [SerializeField] private float gameDayDurationMinutes = 3f; // Real-life minutes per game day (affected by stamina)
    [SerializeField] private float minEventInterval = 30f; // Min seconds between events
    [SerializeField] private float maxEventInterval = 90f; // Max seconds between events

    private const float BAR_WIDTH = 300f;
    private const float BAR_HEIGHT = 30f;
    private const float MIN_DAY_DURATION = 2f; // Minimum minutes per day
    private const float MAX_DAY_DURATION = 5f; // Maximum minutes per day

    private float gameTimeHours = 6f; // Start at 6:00 AM
    private float nextEventTime;
    private bool isEventActive = false;
    private GameEvent currentEvent;

    void Start()
    {
        SetMaxHealth(MaxHealth);
        SetMaxStamina(MaxStamina);
        SetMaxIntellect(MaxIntellect);
        UpdateMoneyText();
        UpdateTimeText();
        ScheduleNextEvent();
        StartCoroutine(GameTimeLoop());
    }

    void Update()
    {
        // Test inputs
        // if (Input.GetKeyDown(KeyCode.Q)) SetHealth(-20);
        // if (Input.GetKeyDown(KeyCode.E)) SetHealth(20);
    }

    private IEnumerator GameTimeLoop()
    {
        while (true)
        {
            float secondsPerGameHour = (gameDayDurationMinutes * 60f) / 24f;
            yield
            return new WaitForSeconds(secondsPerGameHour);

            if (!isEventActive)
            {
                gameTimeHours += 1f;

                if (gameTimeHours >= 24f)
                {
                    gameTimeHours = 0f;
                }

                UpdateTimeText();

                // Check for sleep penalty at 23:00
                if (gameTimeHours >= 23f && !HasSlept)
                {
                    TriggerSleepPenalty();
                    HasSlept = true;
                }

                // Reset HasSlept at midnight (0:00-1:00)
                if (gameTimeHours >= 0f && gameTimeHours < 1f)
                {
                    HasSlept = false;
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
            stamina = MaxStamina - Stamina,
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
        Time.timeScale = 0f; // Freeze game time

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
        Time.timeScale = 1f; // Unfreeze game time
        currentEvent = null;
        ScheduleNextEvent();
    }

    private void ApplyEventResult(EventResult result)
    {
        if (result.health != 0) SetHealth(result.health);
        if (result.stamina != 0) SetStamina(result.stamina);
        if (result.intellect != 0) SetIntellect(result.intellect);
        if (result.money != 0) SetMoney(Money + result.money);

        if (result.timeSkip > 0)
        {
            gameTimeHours += result.timeSkip;
            if (gameTimeHours >= 24f) gameTimeHours -= 24f;
            UpdateTimeText();
        }
    }

    public void SetHealth(int healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        UpdateBar(healthBarRect, Health, MaxHealth);

        if (Health <= 0)
        {
            GameOver();
        }
    }

    public void SetMaxHealth(int newMaxHealth)
    {
        MaxHealth = newMaxHealth;
        healthBarRect.sizeDelta = new Vector2(BAR_WIDTH, BAR_HEIGHT);
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        UpdateBar(healthBarRect, Health, MaxHealth);
    }

    public void SetStamina(int staminaChange)
    {
        Stamina += staminaChange;
        Stamina = Mathf.Clamp(Stamina, 0, MaxStamina);
        UpdateBar(staminaBarRect, Stamina, MaxStamina);

        // Adjust game day duration based on stamina (lower stamina = slower day)
        float staminaRatio = (float)Stamina / MaxStamina;
        gameDayDurationMinutes = Mathf.Lerp(MAX_DAY_DURATION, MIN_DAY_DURATION, staminaRatio);
    }

    public void SetMaxStamina(int newMaxStamina)
    {
        MaxStamina = newMaxStamina;
        staminaBarRect.sizeDelta = new Vector2(BAR_WIDTH, BAR_HEIGHT);
        Stamina = Mathf.Clamp(Stamina, 0, MaxStamina);
        UpdateBar(staminaBarRect, Stamina, MaxStamina);
    }

    public void SetIntellect(int intellectChange)
    {
        Intellect += intellectChange;
        Intellect = Mathf.Clamp(Intellect, 0, MaxIntellect);
        UpdateBar(intellectBarRect, Intellect, MaxIntellect);
    }

    public void SetMaxIntellect(int newMaxIntellect)
    {
        MaxIntellect = newMaxIntellect;
        intellectBarRect.sizeDelta = new Vector2(BAR_WIDTH, BAR_HEIGHT);
        Intellect = Mathf.Clamp(Intellect, 0, MaxIntellect);
        UpdateBar(intellectBarRect, Intellect, MaxIntellect);
    }

    public void SetMoney(int newMoney)
    {
        Money = newMoney;
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
            moneyText.text = "$" + Money.ToString();
        }
    }

    private void UpdateTimeText()
    {
        if (timetext != null)
        {
            int hours = Mathf.FloorToInt(gameTimeHours);
            int minutes = Mathf.FloorToInt((gameTimeHours - hours) * 60f);
            timetext.text = string.Format("{0:00}:{1:00}", hours, minutes);
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over - Health reached 0");
        // Implement game over logic here
    }
}