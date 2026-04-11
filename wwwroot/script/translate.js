// اختر الزرار والدايرة
const toggleBtn = document.getElementById('toggle-btn');
const circle = document.getElementById('language-circle');

toggleBtn.addEventListener('click', () => {

  // تحديد اللغة اللي هتظهر بعد الضغط
  const nextLang = circle.innerText === "English" ? "en" : "ar";

  // تبديل كل النصوص في الصفحة
  document.querySelectorAll('[data-ar]').forEach(el => {
    el.innerText = nextLang === "ar" ? el.getAttribute('data-ar') : el.getAttribute('data-en');
  });

  // تحديث كلمة الدايرة لتكون اللغة اللي هتتحول إليها المرة القادمة
  circle.innerText = nextLang === "ar" ? "English" : "العربية";

  // تحريك الدايرة يمين ↔ يسار
  toggleBtn.classList.toggle('active');
});
