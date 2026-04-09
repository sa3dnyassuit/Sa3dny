document.addEventListener("DOMContentLoaded", () => {
  function typeText(element, text, speed = 50, callback) {
    let i = 0;
    element.textContent = "";

    const interval = setInterval(() => {
      element.textContent += text[i];
      i++;

      if (i >= text.length) {
        clearInterval(interval);
        if (callback) callback();
      }
    }, speed);
  }

  const successTitle = document.getElementById("successTitle");
  const successText = document.querySelector(".success-text");
  const requestInfo = document.querySelector(".request-info");
  const cardCover = document.getElementById("cardCover");
  const buttons = document.querySelector(".success-buttons");

  // النصوص هنا (مهم جدًا)
  const fullTitle = "Request Sent Successfully";
  const fullText =
    "Your request has been submitted successfully. A service provider will contact you soon.";

  // نخفي العناصر
  requestInfo.style.opacity = 0;
  buttons.style.opacity = 0;

  // نبدأ بعد شوية
  setTimeout(() => {
    // ✍️ typing title
    typeText(successTitle, fullTitle, 50, () => {
      // ✍️ typing text
      typeText(successText, fullText, 25, () => {
        // إظهار request box
        requestInfo.style.transition = "0.6s";
        const wrapper = document.querySelector(".request-box-wrapper");
        cardCover.addEventListener("click", () => {
          cardCover.classList.add("open");

          buttons.style.transition = "0.6s";
          buttons.style.opacity = 1;
          buttons.style.transform = "translateY(0)";
        });
        setTimeout(() => {
          wrapper.classList.add("show");
        }, 800);
      });
    });
  }, 2000);

  // لما تدوسي على الغطا
  cardCover.addEventListener("click", () => {
    cardCover.classList.add("open");
  });
});
