namespace VisionProView
{
    partial class DisplayView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayView));
            this.Display = new Cognex.VisionPro.Display.CogDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.Display)).BeginInit();
            this.SuspendLayout();
            // 
            // Display
            // 
            this.Display.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.Display.ColorMapLowerRoiLimit = 0D;
            this.Display.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.Display.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.Display.ColorMapUpperRoiLimit = 1D;
            this.Display.DoubleTapZoomCycleLength = 2;
            this.Display.DoubleTapZoomSensitivity = 2.5D;
            this.Display.Location = new System.Drawing.Point(0, 0);
            this.Display.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.Display.MouseWheelSensitivity = 1D;
            this.Display.Name = "Display";
            this.Display.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Display.OcxState")));
            this.Display.Size = new System.Drawing.Size(492, 402);
            this.Display.TabIndex = 246;
            this.Display.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Display_MouseDown);
            this.Display.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Display_MouseUp);
            this.Display.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Display_MouseMove);
            // 
            // DisplayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Display);
            this.Name = "DisplayView";
            this.Size = new System.Drawing.Size(595, 462);
            this.Load += new System.EventHandler(this.DisplayView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Display)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Cognex.VisionPro.Display.CogDisplay Display;
    }
}
