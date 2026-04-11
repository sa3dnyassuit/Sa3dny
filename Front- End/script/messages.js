// 1. قاعدة بيانات الشات (خليها زي ما هي)
const chatData = {
  "Dr. Ahmed Ali": [
    { type: "incoming", text: "أهلاً يا محمد، بخصوص ميعاد الاستشارة بكرة؟" },
    { type: "outgoing", text: "أهلاً دكتور أحمد، أيوه تمام هاجي في الميعاد" },
    { type: "incoming", text: "تمام، متنساش تجيب معاك التحاليل القديمة عشان نراجعها" },
    { type: "outgoing", text: "حاضر يا دكتور، مجهز كل الورق" },
    { type: "incoming", text: "ممتاز، أشوفك بكرة الساعة 10 الصبح بإذن الله" },
  ],
  "Eng. Sara Ahmed": [
    { type: "incoming", text: "محمد، المشروع خلص ومستني مراجعتك" },
  ],
  "Mohamed Cleaner": [
    { type: "incoming", text: "يا فندم أنا قدامي نص ساعة وأوصل" },
    { type: "outgoing", text: "تمام يا محمد، أنا موجود في البيت مستنى حضرتك" },
    { type: "incoming", text: "تمام" },
  ],
};

// 2. دالة فتح الشات (معدلة لتجنب الأخطاء)
function openChat(name, status) {
  const emptyChat = document.getElementById("emptyChat");
  const activeChat = document.getElementById("activeChat");
  
  if (emptyChat && activeChat) {
    emptyChat.style.display = "none";
    activeChat.style.display = "flex";

    document.getElementById("chatUserName").innerText = name;
    document.getElementById("chatUserStatus").innerText = status;

    const chatBody = document.getElementById("chatBody");
    chatBody.innerHTML = "";

    if (chatData[name]) {
      chatData[name].forEach((msg) => {
        const msgDiv = document.createElement("div");
        msgDiv.className = `message ${msg.type}`;
        msgDiv.innerHTML = `<p>${msg.text}</p>`;
        chatBody.appendChild(msgDiv);
      });
    } else {
      chatBody.innerHTML = `<div style="text-align:center; color:#94a3b8; margin-top:20px;">No messages yet. Say Hi!</div>`;
    }
    chatBody.scrollTop = chatBody.scrollHeight;
  }
}

// 3. البحث والمودال (محميين بـ Check عشان ميعطلوش الـ Nav)
document.addEventListener('DOMContentLoaded', () => {
    
    // كود البحث
    const msgSearchInput = document.getElementById("userSearch");
    if (msgSearchInput) {
        msgSearchInput.addEventListener("keyup", function () {
            const searchTerm = this.value.toLowerCase();
            const userCards = document.querySelectorAll(".user-card");
            userCards.forEach((card) => {
                const userName = card.querySelector("h4").innerText.toLowerCase();
                card.style.display = userName.includes(searchTerm) ? "flex" : "none";
            });
        });
    }
});

// 4. التحكم في المودال (Price Model)
function togglePriceModal() {
  const modal = document.getElementById("priceModal");
  if (modal) {
    if (modal.style.display === "flex") {
      modal.style.display = "none";
      // Reset
      const offerForm = document.getElementById("offerForm");
      if (offerForm) offerForm.style.display = "block";
      document.getElementById("loadingStep").style.display = "none";
      document.getElementById("successMessage").style.display = "none";
      document.getElementById("offerAmount").value = "";
      document.getElementById("errorMsg").style.display = "none";
    } else {
      modal.style.display = "flex";
    }
  }
}

// 5. معالجة العرض (Process Offer)
function processOffer() {
  const amountInput = document.getElementById("offerAmount");
  const errorMsg = document.getElementById("errorMsg");
  const wrapper = document.querySelector(".price-input-wrapper");

  if (amountInput && amountInput.value > 0) {
    if (errorMsg) errorMsg.style.display = "none";
    if (wrapper) wrapper.classList.remove("input-error");

    const tips = [
      "Tip: Always check provider reviews before booking",
      "Did you know? You can track your booking in 'My Wallet'",
      "Sa3dny Tip: Safety first! Verified providers have a green badge"
    ];
    const randomTip = tips[Math.floor(Math.random() * tips.length)];
    const tipEl = document.getElementById("randomTip");
    if (tipEl) tipEl.innerText = randomTip;

    document.getElementById("offerForm").style.display = "none";
    document.getElementById("loadingStep").style.display = "block";

    setTimeout(() => {
      document.getElementById("loadingStep").style.display = "none";
      document.getElementById("successMessage").style.display = "block";
    }, 3000);

  } else {
    if (errorMsg) errorMsg.style.display = "block";
    if (wrapper) {
        wrapper.classList.add("input-error");
        setTimeout(() => wrapper.classList.remove("input-error"), 300);
    }
  }
}

function goToWallet() {
  window.location.href = "./my-wallet.html";
}