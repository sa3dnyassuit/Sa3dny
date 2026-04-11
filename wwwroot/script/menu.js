
// ======= Sidebar الشمال =======
const openMenu = document.getElementById("openMenu");
const sidebar = document.getElementById("sidebar");
const overlay = document.getElementById("overlay");
const closeSidebar = document.getElementById("closeSidebar");

// open sidebar
openMenu.addEventListener("click", () => {
  sidebar.classList.add("active");
  overlay.classList.add("active");
});

// close sidebar
closeSidebar.addEventListener("click", closeAll);
overlay.addEventListener("click", closeAll);

function closeAll() {
  sidebar.classList.remove("active");
  profileSidebar.classList.remove("active");
  overlay.classList.remove("active");

  // كمان نقفل السيرش لو مفتوح
  sidebar.classList.remove("search-active");
  searchInput.value = "";
  resetSearch();
}

// ======= Search Toggle =======
const searchBtn = document.getElementById("searchBtn");
searchBtn.addEventListener("click", () => {
  sidebar.classList.toggle("search-active");

  if (sidebar.classList.contains("search-active")) {
    searchInput.focus();
  } else {
    // لو اتقفل السيرش نرجع كل حاجة
    searchInput.value = "";
    resetSearch();
  }
});

// ======= Search Filter =======
const searchInput = document.getElementById("sidebarSearchInput");

const subGroups = document.querySelectorAll(".sub-group");
const menuItems = document.querySelectorAll(".menu-item");

searchInput.addEventListener("input", function () {
  const value = this.value.toLowerCase().trim();

  // ===== البحث داخل الـ sub-groups =====
  subGroups.forEach(group => {
    const groupTitle = group.querySelector(".sub-title")?.textContent.toLowerCase() || "";
    const links = group.querySelectorAll("a");

    let groupMatch = false;

    // لو اسم القسم نفسه مطابق
    if (groupTitle.includes(value)) {
      groupMatch = true;
      links.forEach(link => link.style.display = "block");
    } else {
      // ندور داخل اللينكات
      links.forEach(link => {
        const text = link.textContent.toLowerCase();

        if (text.includes(value)) {
          link.style.display = "block";
          groupMatch = true;
        } else {
          link.style.display = "none";
        }
      });
    }

    // إظهار أو إخفاء الـ group بالكامل
    group.style.display = groupMatch ? "block" : "none";
  });

  // ===== menu items (زي Contact Us) =====
  menuItems.forEach(item => {
    const text = item.textContent.toLowerCase();

    if (text.includes(value)) {
      item.style.display = "block";
    } else {
      item.style.display = value === "" ? "block" : "none";
    }
  });
});
document.addEventListener("click", function (e) {
  const isInsideSidebar = sidebar.contains(e.target);
  const isSearchBtn = searchBtn.contains(e.target);

  // لو الضغط كان جوه السايد بار ومش على زرار السيرش
  if (isInsideSidebar && !isSearchBtn) {
    sidebar.classList.remove("search-active");
    searchInput.value = "";
    resetSearch();
  }
});

// ======= Reset function =======
function resetSearch() {
  allLinks.forEach(link => {
    link.style.display = "block";
  });
}
// ======= Profile Sidebar اليمين =======
const profileIcon = document.getElementById("openProfile");
const profileSidebar = document.getElementById("profileSidebar");
const closeProfileSidebar = document.getElementById("closeProfileSidebar");

profileIcon.addEventListener("click", () => {
  profileSidebar.classList.add("active");
  overlay.classList.add("active");
});

closeProfileSidebar.addEventListener("click", () => {
  profileSidebar.classList.remove("active");
  overlay.classList.remove("active");
});

// ======= Dropdown Menu Navbar =======
const dropdowns = document.querySelectorAll(".nav-links li.dropdown");

dropdowns.forEach((dropdown) => {
  // للشاشات الصغيرة (موبايل)
  dropdown.addEventListener("click", (e) => {
    if (window.innerWidth <= 768) {
      e.preventDefault(); // يمنع الـ link من التحرك
      dropdown.classList.toggle("active");
    }
  });
});

// ======= إغلاق الـ dropdown عند تغيير حجم الشاشة =======
window.addEventListener("resize", () => {
  if (window.innerWidth > 768) {
    dropdowns.forEach((dropdown) => dropdown.classList.remove("active"));
  }
});
