namespace Tilia.CameraRigs.OpenXR
{
    using UnityEngine;
    using UnityEngine.XR;
    using Zinnia.Extension;
    using Zinnia.Tracking.CameraRig;

    /// <summary>
    /// Provides the description for an OpenXR CameraRig node element.
    /// </summary>
    public class OpenXRNodeRecord : BaseDeviceDetailsRecord
    {
        [Tooltip("The Node Type for the record.")]
        [SerializeField]
        private XRNode nodeType;
        /// <summary>
        /// The Node Type for the record.
        /// </summary>
        public XRNode NodeType
        {
            get
            {
                return nodeType;
            }
            set
            {
                nodeType = value;
            }
        }

        [Tooltip("The PassthroughManager for handling the camera passthrough.")]
        [SerializeField]
        private BasePassthroughManager passthroughManager;
        /// <summary>
        /// The <see cref="PassthroughManager"/> for handling the camera passthrough.
        /// </summary>
        public BasePassthroughManager PassthroughManager
        {
            get
            {
                return passthroughManager;
            }
            set
            {
                passthroughManager = value;
            }
        }

        /// <inheritdoc/>
        public override XRNode XRNodeType { get { return NodeType; } protected set { NodeType = value; } }
        /// <inheritdoc/>
        public override int Priority { get => 0; protected set => throw new System.NotImplementedException(); }
        /// <inheritdoc/>
        public override bool HasPassThroughCamera { get => PassthroughManager != null; protected set => throw new System.NotImplementedException(); }

        /// <inheritdoc/>
        protected override void EnablePassThrough()
        {
            if (!HasPassThroughCamera)
            {
                return;
            }

            PassthroughManager.ActivatePassthrough();
            base.EnablePassThrough();
        }

        /// <inheritdoc/>
        protected override void DisablePassThrough()
        {
            if (!HasPassThroughCamera)
            {
                return;
            }

            PassthroughManager.DeactivatePassthrough();
            base.DisablePassThrough();
        }

        /// <summary>
        /// Sets the <see cref="NodeType"/>.
        /// </summary>
        /// <param name="index">The index of the <see cref="XRNode"/>.</param>
        public virtual void SetNodeType(int index)
        {
            NodeType = EnumExtensions.GetByIndex<XRNode>(index);
        }
    }
}