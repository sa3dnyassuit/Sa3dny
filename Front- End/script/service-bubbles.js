document.addEventListener("DOMContentLoaded", function () {

  document.querySelectorAll(".service-bubble").forEach((bubble) => {

    bubble.addEventListener("click", function (e) {
      e.preventDefault();

      bubble.style.animation = "none";

      explodeStrong(bubble);

      setTimeout(() => {
        bubble.classList.add("explode");
      }, 120);

      setTimeout(() => {
        window.location.href = bubble.href;
      }, 1100);
    });

  });

});


function explodeStrong(el){

  const rect = el.getBoundingClientRect();
  const cx = rect.left + rect.width / 2;
  const cy = rect.top + rect.height / 2;

  /* flash effect */
  const flash = document.createElement("div");
  flash.className = "explosion-flash";
  document.body.appendChild(flash);
  setTimeout(() => flash.remove(), 300);

  /* screen shake */
  document.body.classList.add("shake");
  setTimeout(() => document.body.classList.remove("shake"), 400);

  /* strong particles */
  const particlesCount = 130;

  for(let i = 0; i < particlesCount; i++){

    const p = document.createElement("div");
    p.className = "particle";

    const size = 14 + Math.random() * 26;
    p.style.width = size + "px";
    p.style.height = size + "px";

    p.style.left = cx + "px";
    p.style.top = cy + "px";

    const angle = Math.random() * Math.PI * 2;
    const dist = 350 + Math.random() * 600;

    p.style.setProperty("--x", Math.cos(angle) * dist + "px");
    p.style.setProperty("--y", Math.sin(angle) * dist + "px");

    document.body.appendChild(p);

    setTimeout(() => p.remove(), 1100);
  }
}