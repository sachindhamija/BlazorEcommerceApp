function ShowConfirmationModal() {
    console.log("Opening Modal");
    const modalElement = document.getElementById('bsConfirmationModal');
    const modal = bootstrap.Modal.getOrCreateInstance(modalElement);
    modal.show();
}

function HideConfirmationModal() {
    const modalElement = document.getElementById('bsConfirmationModal');
    const modal = bootstrap.Modal.getOrCreateInstance(modalElement);
    modal.hide();
}
