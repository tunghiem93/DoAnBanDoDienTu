(function () {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation')
    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })


/*** Init Toast ***/
    toastr.options = {
        "progressBar": true
    }
})()

function ConfirmSwalMessage(title, message, btnConfirmText, btnCancelText, action) {
    Swal.fire({
        title: title,
        text: message,
        icon: 'warning',
        showCancelButton: !0,
        confirmButtonColor: '#34c38f',
        cancelButtonColor: '#f46a6a',
        confirmButtonText: btnConfirmText
        //cancelButtonText: btnCancelText,
    }).then(function (t) {
        if (t.value) {
            $.ajax({
                type: "get",
                url: action,
                contentType: "application/json; charset=utf-8",
                data: { data: "yourdata" },
                dataType: "json",
                success: function (recData) {
                    if (recData.success) {
                        t.value && Swal.fire(
                            "Xóa!",
                            "Bạn đã xóa thành công.", "success"
                        ).then(function (y) {
                            window.location.reload();
                        });                        
                    }
                    else {
                        Command: toastr["error"]("Xóa không thành công! Vui lòng kiểm tra thông tin!")
                    }
                },
                error: function () {
                    Command: toastr["error"]("Xóa không thành công! Vui lòng kiểm tra thông tin!")
                }
            });
        }
    })
}