using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegPage
{
    public class JFacebook
    {
        public class EditName
        {
            #region Param_EditName
            public class Action
            {
                public string cmd { get; set; }
                public string target { get; set; }
                public string html { get; set; }
                public bool replaceifexists { get; set; }
            }
            public class Consistency
            {
                public int rev { get; set; }
            }
            public class GAN1fSS
            {
                public string type { get; set; }
                public string src { get; set; }
            }
            public class RsrcMap
            {
                public GAN1fSS gAN1fSS { get; set; }
            }
            public class Hblp
            {
                public Consistency consistency { get; set; }
                public RsrcMap rsrcMap { get; set; }
            }
            public class Hsrp
            {
                public Hblp hblp { get; set; }
            }
            public class Context
            {
            }
            public class Markup
            {
                public string __html { get; set; }
            }
            public class Error
            {
                public Context context { get; set; }
                public Markup markup { get; set; }
                public object callerHash { get; set; }
            }
            #endregion
            public class Payload
            {
                public Error error { get; set; }
                public long draftID { get; set; }
                public object pageID { get; set; }
                public List<Action> actions { get; set; }
                public string ajax_response_token { get; set; }
                public bool contentless_response { get; set; }
                public List<string> displayResources { get; set; }
                public Hsrp hsrp { get; set; }
                public Payload payload { get; set; }
            }

            public class EditName_Root
            {
                public Payload payload { get; set; }
            }
        }

        public class EditCategory
        {

            #region EditCategory
            public class Action
            {
                public string cmd { get; set; }
                public string target { get; set; }
                public string html { get; set; }
                public bool replaceifexists { get; set; }
                public bool allownull { get; set; }
            }

            public class Consistency
            {
                public int rev { get; set; }
            }

            public class Gn940X5
            {
                public string type { get; set; }
                public string src { get; set; }
            }

            public class GAN1fSS
            {
                public string type { get; set; }
                public string src { get; set; }
            }

            public class RQyielL
            {
                public string type { get; set; }
                public string src { get; set; }
            }

            public class RsrcMap
            {
                public Gn940X5 Gn940X5 { get; set; }
                public GAN1fSS gAN1fSS { get; set; }
                public RQyielL RQyielL { get; set; }
            }

            public class Hblp
            {
                public Consistency consistency { get; set; }
                public RsrcMap rsrcMap { get; set; }
            }

            public class Hsrp
            {
                public Hblp hblp { get; set; }
            }
            #endregion

            public class Payload
            {
                public List<Action> actions { get; set; }
                public string ajax_response_token { get; set; }
                public bool contentless_response { get; set; }
                public List<string> displayResources { get; set; }
                public Hsrp hsrp { get; set; }
            }

            public class EditCategory_Root
            {
                public Payload payload { get; set; }
            }
        }
    }
}
