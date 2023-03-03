using System.Collections;

public class ZoomOut : ZoomButton
{
    public override IEnumerator Zoom()
    {
        while (_camera.fieldOfView < _cameraZoom.MaxZoom)
        {
            _cameraZoom.ZoomOut();
            yield return null;
        }
    }
}