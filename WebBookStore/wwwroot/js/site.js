// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// buttons
var btnDescription = document.getElementById('btnDescription');
var btnSpecifications = document.querySelector('#btnSpecifications');

// Book description 
descriptionText = document.getElementById('description');

//table
SpecificationsText = document.getElementById('Specifications');

function ShowDescription() {
    if (this.classList.contains('Inactive')) {
        this.classList.remove('Inactive');
        this.classList.add('Active');
        btnSpecifications.classList.remove('Active');
        btnSpecifications.classList.add('Inactive');
        descriptionText.style.display = 'block'
        SpecificationsText.style.display = 'none'
    }


}
function ShowSpecifications() {
    if (this.classList.contains('Inactive')) {
        this.classList.remove('Inactive');
        this.classList.add('Active');
        btnDescription.classList.remove('Active');
        btnDescription.classList.add('Inactive');
        descriptionText.style.display = 'none'
        SpecificationsText.style.display = 'table'
    }


}

btnDescription.addEventListener('click', ShowDescription);
btnSpecifications.addEventListener('click', ShowSpecifications);

