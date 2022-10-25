
(function (){
    window.QuillFunctions={
        createQuill: function (quillElement){
            var options = {
                debug: 'info',
                modules: {
                    toolbar: '#toolbar'
                },
                placeholder: 'Type here',
                readOnly: false,
                theme: snow
            }
        }
        getQuillContent: function (quillControl) {
            return JSON.stringify(quillControl.__quill.getContents());
        }
    }
})