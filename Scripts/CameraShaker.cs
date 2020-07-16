using System.Collections;
using UnityEngine;

namespace Kogane
{
	/// <summary>
	/// カメラを揺らす設定を管理するインターフェイス
	/// </summary>
	public interface ICameraShakerSettings
	{
		//================================================================================
		// プロパティ
		//================================================================================
		/// <summary>
		/// カメラを揺らす時間（秒）
		/// </summary>
		float Duration { get; }

		/// <summary>
		/// カメラを揺らす強さ
		/// </summary>
		float Magnitude { get; }

		/// <summary>
		/// Time.deltaTime ではなく Time.unscaledDeltaTime を使う場合 true
		/// </summary>
		bool UseUnscaledDeltaTime { get; }
	}

	/// <summary>
	/// カメラを揺らすコンポーネント
	/// </summary>
	[DisallowMultipleComponent]
	public sealed class CameraShaker : MonoBehaviour
	{
		//================================================================================
		// 変数
		//================================================================================
		private bool    m_isInit;
		private Vector3 m_initPos;

		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// 初期化される時に呼び出されます
		/// </summary>
		private void Awake()
		{
			Init();
		}

		/// <summary>
		/// 初期化します
		/// </summary>
		private void Init()
		{
			if ( m_isInit ) return;
			m_isInit = true;

			m_initPos = transform.localPosition;
		}

		/// <summary>
		/// カメラを揺らします
		/// </summary>
		public void Shake( ICameraShakerSettings settings )
		{
			Shake
			(
				duration: settings.Duration,
				magnitude: settings.Magnitude,
				useUnscaledDeltaTime: settings.UseUnscaledDeltaTime
			);
		}

		/// <summary>
		/// カメラを揺らします
		/// </summary>
		public void Shake
		(
			float duration,
			float magnitude,
			bool  useUnscaledDeltaTime
		)
		{
			StartCoroutine( DoShake( duration, magnitude, useUnscaledDeltaTime ) );
		}

		/// <summary>
		/// カメラを揺らします
		/// </summary>
		private IEnumerator DoShake
		(
			float duration,
			float magnitude,
			bool  useUnscaledDeltaTime
		)
		{
			Init();

			var elapsed = 0f;

			while ( elapsed < duration )
			{
				var x = m_initPos.x + Random.Range( -1f, 1f ) * magnitude;
				var y = m_initPos.y + Random.Range( -1f, 1f ) * magnitude;

				transform.localPosition = new Vector3( x, y, m_initPos.z );

				elapsed += useUnscaledDeltaTime
						? Time.unscaledDeltaTime
						: Time.deltaTime
					;

				yield return null;
			}

			transform.localPosition = m_initPos;
		}
	}
}