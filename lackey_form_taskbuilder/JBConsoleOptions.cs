namespace SystemLackey.UI.Forms
{
    public class JBConsoleOptions
    {
        private bool debug;
        private bool info;
        private bool warning;
        private bool error;
        private bool danger;

        public bool Debug
        {
            get { return debug; }
            set { this.debug = value; }
        }

        public bool Info
        {
            get { return info; }
            set { this.info = value; }
        }

        public bool Warning
        {
            get { return warning; }
            set { this.warning = value; }
        }

        public bool Error
        {
            get { return error; }
            set { this.error = value; }
        }

        public bool Danger
        {
            get { return danger; }
            set { this.danger = value; }
        }
    }
}
