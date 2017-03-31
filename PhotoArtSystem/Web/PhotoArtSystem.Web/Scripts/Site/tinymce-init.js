
$(function () {
    tinymce.init({
        selector: '.photoartsystem-tinymce',
        theme: 'modern',
        height: 150,
        setup: function (editor) {
            var editorid = editor.id;

            editor.on('keyup', function (e) {
                var editorById = tinymce.get(editorid);
                var content = editorById.getContent();
                editorById.getElement().value = content;
            });
        },
        plugins: [
          'advlist autolink link lists charmap hr anchor pagebreak spellchecker',
          'searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime nonbreaking',
          'save table contextmenu directionality emoticons template paste textcolor'
        ],
        toolbar: 'undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link | forecolor backcolor emoticons'
    });
})