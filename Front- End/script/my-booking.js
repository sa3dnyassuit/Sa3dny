//Booking Fileration
document.addEventListener('DOMContentLoaded', function() {
    const filterButtons = document.querySelectorAll('.filter-btn');
    const bookingCards = document.querySelectorAll('.booking-card-v2');

    filterButtons.forEach(button => {
        button.addEventListener('click', () => {
            // 1. تغيير الزرار النشط (Active)
            document.querySelector('.filter-btn.active').classList.remove('active');
            button.classList.add('active');

            const filterValue = button.textContent.trim();

            // 2. فلترة الكروت
            bookingCards.forEach(card => {
                const cardCategory = card.getAttribute('data-category');
                
                if (filterValue === 'All Bookings' || filterValue === cardCategory) {
                    card.style.display = 'flex'; // إظهار الكارت
                    card.style.animation = 'fadeIn 0.5s ease forwards'; // حركة دخول شيك
                } else {
                    card.style.display = 'none'; // إخفاء الكارت
                }
            });
        });
    });
});