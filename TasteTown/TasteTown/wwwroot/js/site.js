(function () {
    'use strict'
    var forms = document.querySelectorAll('.needs-validation')
    Array.prototype.slice.call(forms).forEach(function (form) {
        form.addEventListener('submit', function (event) {
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            } else {
                // For this demo, prevent actual submission and show a success message
                event.preventDefault()
                form.classList.remove('was-validated')
                form.reset()
                alert('Reservation request sent! We will contact you to confirm.')
            }
            form.classList.add('was-validated')
        }, false)
    })
})()