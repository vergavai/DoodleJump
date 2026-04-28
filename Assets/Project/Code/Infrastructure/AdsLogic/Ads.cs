using GoogleMobileAds.Api;
using Project.Code.Gameplay.Player.PlayerDeathLogic;
using UnityEngine;
using Zenject;

namespace Project.Code.Infrastructure.AdsLogic
{
    public class Ads : MonoBehaviour
    {
        private InterstitialAd _interstitial;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void OnEnable()
        {
            MobileAds.Initialize(_ => { });
            _signalBus.Subscribe<PlayerDiedSignal>(OnPlayerDeath);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<PlayerDiedSignal>(OnPlayerDeath);
        }

        private void OnPlayerDeath()
        {
            ShowInterstitial();
        }

        private void ShowInterstitial()
        {
            InterstitialAd.Load("id", new AdRequest(), (ad, error) => _interstitial = ad);

            _interstitial?.Show();
        }
    }
}