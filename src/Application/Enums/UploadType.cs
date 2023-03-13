using System.ComponentModel;

namespace DreamWeddsManager.Application.Enums
{
    public enum UploadType : byte
    {
        [Description(@"Images\Meta")]
        MetaTag,

        [Description(@"Images\Blog")]
        Blog,

        [Description(@"Images\Template")]
        Template,

        [Description(@"Images\ProfilePictures")]
        ProfilePicture,

        [Description(@"Documents")]
        Document
    }
}
