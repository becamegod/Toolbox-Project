using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoundGenerator : MonoBehaviour
{
    [SerializeField] float thickness = 1;
    [SerializeField] bool ignoreRaycast = true;

    #region LEFT
    [Header("Left")]
    [SerializeField] bool leftSide = true;

    [ShowIf("leftSide")]
    [SerializeField] bool overrideLeftThickness;

    [ShowIf("overrideLeftThickness")]
    [SerializeField] float leftThickness = 1;
    #endregion

    #region RIGHT
    [Header("Right")]
    [SerializeField] bool rightSide = true;

    [ShowIf("rightSide")]
    [SerializeField] bool overrideRightThickness;

    [ShowIf("overrideRightThickness")]
    [SerializeField] float rightThickness = 1;
    #endregion

    #region BACK
    [Header("Back")]
    [SerializeField] bool backSide = true;

    [ShowIf("backSide")]
    [SerializeField] bool overrideBackThickness;

    [ShowIf("overrideBackThickness")]
    [SerializeField] float backThickness = 1;
    #endregion

    #region FRONT
    [Header("Front")]
    [SerializeField] bool frontSide = true;

    [ShowIf("frontSide")]
    [SerializeField] bool overrideFrontThickness;

    [ShowIf("overrideFrontThickness")]
    [SerializeField] float frontThickness = 1;
    #endregion

    #region BOTTOM
    [Header("Bottom")]
    [SerializeField] bool bottomSide = true;

    [ShowIf("bottomSide")]
    [SerializeField] bool overrideBottomThickness;

    [ShowIf("overrideBottomThickness")]
    [SerializeField] float bottomThickness = 1;
    #endregion

    #region TOP
    [Header("Top")]
    [SerializeField] bool topSide = true;

    [ShowIf("topSide")]
    [SerializeField] bool overrideTopThickness;

    [ShowIf("overrideTopThickness")]
    [SerializeField] float topThickness = 1;
    #endregion

    private void Awake()
    {
        var box = GetComponent<BoxCollider>();
        var scale = Vector3.zero;
        var pos = Vector3.zero;
        var layer = (ignoreRaycast) ? LayerMask.NameToLayer("Ignore Raycast") : 0;

        if (leftSide)
        {
            #region left side
            var leftWall = new GameObject("LeftSide");
            leftWall.layer = layer;
            leftWall.AddComponent<BoxCollider>();
            var t = (overrideLeftThickness) ? leftThickness : thickness;

            scale = transform.lossyScale;
            scale.x = t;
            leftWall.transform.localScale = scale;

            pos = box.center;
            pos.x -= box.size.x / 2;
            pos = transform.TransformPoint(pos);
            pos.x -= t / 2;
            leftWall.transform.position = pos;

            leftWall.transform.SetParent(transform, true);
            #endregion
        }

        if (rightSide)
        {
            #region right side
            var rightWall = new GameObject("RightSide");
            rightWall.layer = layer;
            rightWall.AddComponent<BoxCollider>();
            var t = (overrideRightThickness) ? rightThickness : thickness;

            scale = transform.lossyScale;
            scale.x = t;
            rightWall.transform.localScale = scale;

            pos = box.center;
            pos.x += box.size.x / 2;
            pos = transform.TransformPoint(pos);
            pos.x += t / 2;
            rightWall.transform.position = pos;

            rightWall.transform.SetParent(transform, true);
            #endregion
        }

        if (frontSide)
        {
            #region front side
            var frontWall = new GameObject("FrontSide");
            frontWall.layer = layer;
            frontWall.AddComponent<BoxCollider>();
            var t = (overrideFrontThickness) ? frontThickness : thickness;

            scale = transform.lossyScale;
            scale.z = t;
            frontWall.transform.localScale = scale;

            pos = box.center;
            pos.z -= box.size.z / 2;
            pos = transform.TransformPoint(pos);
            pos.z -= t / 2;
            frontWall.transform.position = pos;

            frontWall.transform.SetParent(transform, true);
            #endregion
        }

        if (backSide)
        {
            #region back side
            var backWall = new GameObject("BackSide");
            backWall.layer = layer;
            backWall.AddComponent<BoxCollider>();
            var t = (overrideBackThickness) ? backThickness : thickness;

            scale = transform.lossyScale;
            scale.z = t;
            backWall.transform.localScale = scale;

            pos = box.center;
            pos.z += box.size.z / 2;
            pos = transform.TransformPoint(pos);
            pos.z += t / 2;
            backWall.transform.position = pos;

            backWall.transform.SetParent(transform, true);
            #endregion
        }

        if (bottomSide)
        {
            #region bottom side
            var bottomWall = new GameObject("BottomSide");
            bottomWall.layer = layer;
            bottomWall.AddComponent<BoxCollider>();
            var t = (overrideBottomThickness) ? bottomThickness : thickness;

            scale = transform.lossyScale;
            scale.y = t;
            bottomWall.transform.localScale = scale;

            pos = box.center;
            pos.y -= box.size.y / 2;
            pos = transform.TransformPoint(pos);
            pos.y -= t / 2;
            bottomWall.transform.position = pos;

            bottomWall.transform.SetParent(transform, true);
            #endregion
        }

        if (topSide)
        {
            #region top side
            var topWall = new GameObject("TopSide");
            topWall.layer = layer;
            topWall.AddComponent<BoxCollider>();
            var t = (overrideTopThickness) ? topThickness : thickness;

            scale = transform.lossyScale;
            scale.y = t;
            topWall.transform.localScale = scale;

            pos = box.center;
            pos.y += box.size.y / 2;
            pos = transform.TransformPoint(pos);
            pos.y += t / 2;
            topWall.transform.position = pos;

            topWall.transform.SetParent(transform, true);
            #endregion
        }
    }
}
