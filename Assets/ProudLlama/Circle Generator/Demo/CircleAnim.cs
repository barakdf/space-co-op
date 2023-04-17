using UnityEngine;
using ProudLlama.CircleGenerator;

public class CircleAnim : MonoBehaviour {
    [SerializeField]
    FillCircleGenerator fillCircle;
    [SerializeField]
    CircleGenerator dashCircle;
    [SerializeField]
    StrokeCircleGenerator strokeCircle;
    CircleGeneratorStrokeGetterVisitor getterVisitor = new CircleGeneratorStrokeGetterVisitor();


    float startTime;
    float lerpTime = 1;
    
    bool increase = true;
    void Start() {
        startTime = Time.time;
        SetCircleColor(true);
    }
    public void resetCircle() {
        // this.reset = true;
        startTime = Time.time;
        lerpTime = 20;
        SetCircleColor(false);
        // Color readyColor = ColorUtility.TryParseHtmlString("9EFFAE", out Color parsedColor) ? parsedColor : Color.white;
        
        
    }
    public void SetCircleColor(bool abilityReady) {
        MeshRenderer meshRenderer = fillCircle.GetComponent<MeshRenderer>();
        if (meshRenderer != null) {

            meshRenderer.sharedMaterial.color = abilityReady ? Color.green : Color.red;
        }
        
    }
    void Update() {
        CircleData fillCircleCircleData = fillCircle.CircleData;
        fillCircleCircleData.Completion = GetDegrees();
        fillCircle.CircleData = fillCircleCircleData;
        fillCircle.Generate();

        CircleData dashCircleCircleData = dashCircle.CircleData;
        dashCircleCircleData.Angle = GetDegrees();
        dashCircle.CircleData = dashCircleCircleData;
        //For passing StrokeData, we can use the visitor pattern (Accept()) if we want to use the abstract CircleGenerator class
        dashCircle.Accept(getterVisitor);
        StrokeData dashCircleStrokeData = getterVisitor.StrokeData;
        dashCircleStrokeData.StrokeSize = GetSize();
        dashCircle.Accept(new CircleGeneratorStrokeSetterVisitor(dashCircleStrokeData));
        dashCircle.Generate();

        // Or simply reference the concrete implementation
        StrokeData strokeCircleStrokeData = strokeCircle.StrokeData;
        strokeCircleStrokeData.StrokeSize = GetSize();
        strokeCircle.StrokeData = strokeCircleStrokeData;
        strokeCircle.Generate();
    }

    float GetDegrees() {
        float interpolant = GetInterpolant();
        float degrees = Mathf.Clamp(interpolant * 360, 0, 360);
        return degrees;
    }

    float GetSize() {
        float interpolant = GetInterpolant();
        float size = Mathf.Clamp((interpolant * 0.1f) + 0.1f, 0.1f, 0.2f);
        return size;
    }

    float GetInterpolant() {
        if (Time.time - startTime > lerpTime) {
            // startTime = Time.time;
            increase = !increase;
            // Destroy(gameObject);
            // return 0;
            
        }
        float timeDif = Time.time - startTime;
        float t = timeDif / lerpTime;
        float interpolant = ParametricBlend(t);
        if (increase == false) {
            interpolant = 1;
        }
        return interpolant;
    }

    float ParametricBlend(float t) {
        float alpha = 2.1f;
        float sqt = t * t;
        return sqt / (alpha * (sqt - t) + 1.0f);
    }
}
