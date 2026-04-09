document.addEventListener('DOMContentLoaded', function() {
    const cameraBtn = document.getElementById('cameraBtn');
    const fileInput = document.getElementById('fileInput');
    const profileDisplay = document.getElementById('profileDisplay');
    
    const modal = document.getElementById('customModal');
    const modalContent = document.getElementById('modalContent');
    const confirmBtn = document.getElementById('confirmBtn');
    const cancelBtn = document.getElementById('cancelBtn');
    
    let tempFile = null;

    cameraBtn.addEventListener('click', () => fileInput.click());

    fileInput.addEventListener('change', function() {
        if (this.files && this.files[0]) {
            tempFile = this.files[0];
            // نرجع شكل الـ Modal للأصل لو كان اتغير قبل كدة
            resetModal(); 
            modal.classList.add('active');
        }
    });

    // لما يدوس "Yes, Update"
    confirmBtn.addEventListener('click', function() {
        const reader = new FileReader();
        reader.onload = function(e) {
            profileDisplay.src = e.target.result;
            
            // تحويل الـ Modal لشكل "النجاح"
            showSuccessState();
        };
        reader.readAsDataURL(tempFile);
    });

    // وظيفة لإظهار حالة النجاح
    function showSuccessState() {
        modalContent.innerHTML = `
            <div class="modal-icon success-anim">
                <i class="fa-solid fa-circle-check" style="color: #27ae60;"></i>
            </div>
            <h2>Updated Successfully!</h2>
            <p>Your profile picture has been updated to the new one.</p>
            <div class="modal-buttons">
                <button onclick="closeModal()" class="modal-btn btn-yes" style="width: 100%;">Done</button>
            </div>
        `;
    }

    // وظيفة لإعادة الـ Modal لشكلة الطبيعي (الأساسي)
    function resetModal() {
        modalContent.innerHTML = `
            <div class="modal-icon">
                <i class="fa-solid fa-circle-question"></i>
            </div>
            <h2>Update Photo?</h2>
            <p>Are you sure you want to change your profile picture?</p>
            <div class="modal-buttons">
                <button id="cancelBtn" class="modal-btn btn-no">Cancel</button>
                <button id="confirmBtn" class="modal-btn btn-yes">Yes, Update</button>
            </div>
        `;
        // لازم نربط الأحداث تاني لأن الـ innerHTML بيمسح الـ Events القديمة
        document.getElementById('cancelBtn').onclick = closeModal;
        document.getElementById('confirmBtn').onclick = () => confirmBtn.click(); 
        // الأفضل نستخدم الـ logic اللي فوق بس دي للتبسيط
        location.reload; // أو ببساطة نربط الـ Listeners تاني (الأفضل هو الكود المنظم)
    }

    // وظائف الإغلاق
    window.closeModal = function() {
        modal.classList.remove('active');
        fileInput.value = ""; 
    };

    cancelBtn.onclick = closeModal;
});