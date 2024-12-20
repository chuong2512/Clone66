﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using ICEBOOO;

public class SettingsView : MonoBehaviour
{
    public Text titleText;
    public Toggle musicToggle;
    public Toggle screenButtonsToggle;
    public Button closeButton;
    public AudioPlayer audioPlayer;

    private UnityAction onCloseCallback;

    private void Awake()
    {
        titleText.text = ConstantGame.Text.Settings;

        musicToggle.isOn = Settings.MusicEnabled;
        musicToggle.GetComponentInChildren<Text>().text = ConstantGame.Text.Music;
        musicToggle.onValueChanged.AddListener((enabled) =>
        {
            Settings.MusicEnabled = enabled;
            PlayToggleAudioClip(enabled);
        });

        screenButtonsToggle.isOn = Settings.ScreenButonsEnabled;
        screenButtonsToggle.GetComponentInChildren<Text>().text = ConstantGame.Text.ScreenButtons;
        screenButtonsToggle.onValueChanged.AddListener((enabled) =>
        {
            Settings.ScreenButonsEnabled = enabled;
            PlayToggleAudioClip(enabled);
        });

        closeButton.GetComponentInChildren<Text>().text = ConstantGame.Text.Close;
        closeButton.onClick.AddListener(() =>
        {
            Hide();
            onCloseCallback.Invoke();
        });

        closeButton.gameObject.GetComponent<PointerHandler>().onPointerDown.AddListener(() =>
        {
            audioPlayer.PlayResumeClip();
        });

        Hide();
    }

    public void Show(UnityAction onCloseCallback)
    {
        this.onCloseCallback = onCloseCallback;
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void PlayToggleAudioClip(bool enabled)
    {
        if (enabled)
        {
            audioPlayer.PlayToggleOnClip();
        }
        else
        {
            audioPlayer.PlayToggleOffClip();
        }
    }
}
