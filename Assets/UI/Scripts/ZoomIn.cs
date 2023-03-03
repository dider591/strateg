using System.Collections;

public class ZoomIn : ZoomButton
{
    public override IEnumerator Zoom()
    {
        while (_camera.fieldOfView > _cameraZoom.MinZoom)
        {
            _cameraZoom.ZoomIn();
            yield return null;
        }
    }
}
