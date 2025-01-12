
    $(document).ready(function () {
        var currentOffset = 0;

    // Hàm cập nhật ngày đầu tuần vào ô input, hoặc ngày hiện tại khi currentOffset là 0
    function updateDateInput() {
            if (currentOffset === 0) {
                // Nếu là tuần hiện tại, hiển thị ngày hôm nay
                const today = new Date();
    document.getElementById('currentDate').placeholder = today.toLocaleDateString('vi-VN');
            } else {
                // Nếu là tuần khác, hiển thị ngày đầu tuần
                const firstDayOfWeek = getFirstDayOfWeek(currentOffset);
    document.getElementById('currentDate').placeholder = firstDayOfWeek.toLocaleDateString('vi-VN');
            }
        }

    // Lấy ngày đầu tuần dựa trên tuần hiện tại và số offset
    function getFirstDayOfWeek(offset) {
            const today = new Date();
            const dayOfWeek = today.getDay() || 7; // 0 => 7 (Chủ nhật là 7)
    today.setDate(today.getDate() - dayOfWeek + 1 + (offset * 7)); // Đầu tuần với offset
    return today;
        }

    // Hàm gọi AJAX để cập nhật lịch
    function updateSchedule() {
        $.ajax({
            url: '/Schedule/PartialSchedule',
            type: 'GET',
            data: { weekOffset: currentOffset },
            success: function (data) {
                $('#schedule-container').html(data);
                updateDateInput();
            }
        });
        }

    // Xử lý khi nhấn "Hiện tại"
    $('#current-week').click(function () {
        currentOffset = 0;
    updateSchedule();
        });

    // Xử lý khi nhấn "Trở về"
    $('#previous-week').click(function () {
        currentOffset -= 1;
    updateSchedule();
        });

    // Xử lý khi nhấn "Tiếp"
    $('#next-week').click(function () {
        currentOffset += 1;
    updateSchedule();
        });

    // Khởi tạo ngày hiện tại trong ô input
    updateDateInput();
    });
