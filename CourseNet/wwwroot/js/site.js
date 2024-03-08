function statistics() {
    $('#statistics_btn').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();        
        if ($('#statistics_box').hasClass('d-none')) {
            $.get('https://localhost:7289/api/statistics', function (data) {
                $('#total_courses').text(data.totalCourses + " курса");
                $('#total_enrollments').text(data.totalEnrollments + " записвания");
                $('#statistics_box').removeClass('d-none');
                $('#statistics_btn').text('Скрий статистика');
                $('#statistics_btn').removeClass('btn-primary');
                $('#statistics_btn').addClass('btn-danger');
            });
        } else {
            $('#statistics_box').addClass('d-none');

            $('#statistics_btn').text('Покажи статистика');
            $('#statistics_btn').removeClass('btn-danger');
            $('#statistics_btn').addClass('btn-primary');
        }
    });
}