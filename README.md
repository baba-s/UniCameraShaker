# UniCameraShaker

カメラを揺らすコンポーネント

## 使用例

!![2020-07-17_203217](https://user-images.githubusercontent.com/6134875/87782005-af391b80-c86c-11ea-80e3-39155222a2ac.png)

カメラに「CameraShaker」をアタッチして  

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    public CameraShaker m_cameraShaker;

    private void Start()
    {
        // 1 秒間、強さ 2 でカメラを揺らします
        // Time.timeScale は無視しません
        m_cameraShaker.Shake( 1, 2, false );
    }
}
```

上記のようなスクリプトを記述することで使用できます  
