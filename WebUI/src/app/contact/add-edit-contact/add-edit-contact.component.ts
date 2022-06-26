import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { ContactApiService } from 'src/app/contact-api.service';


@Component({
  selector: 'app-add-edit-contact',
  templateUrl: './add-edit-contact.component.html',
  styleUrls: ['./add-edit-contact.component.css']
})
export class AddEditContactComponent implements OnInit {

  constructor(private service: ContactApiService) { }

  contactList$!: Observable<any[]>;
  contactCategoriesList$!: Observable<any[]>;
  contactSubCategoriesList$!: Observable<any[]>;


  @Input() contact: any;
  id: number = 0;
  userId: number = 0;
  firstName: string = "";
  lastName: string = "";
  email: string = "";
  categoryId: number = 0;
  subCategoryId: number = 0;
  customSubCategory: string = '';
  phoneNumber!: number;
  dateOfBirth!: string;

  ngOnInit(): void {
    this.id = this.contact.id;
    this.userId = this.contact.userId;
    this.firstName = this.contact.firstName;
    this.lastName = this.contact.lastName;
    this.email = this.contact.email;
    this.categoryId = this.contact.categoryId;
    this.subCategoryId = this.contact.subCategoryId;
    this.customSubCategory = this.contact.customSubCategory;
    this.phoneNumber = this.contact.phoneNumber;
    this.dateOfBirth = this.contact.dateOfBirth;

    this.contactList$ = this.service.getContactList();
    this.contactCategoriesList$ = this.service.getContactCategoriesList();
    this.contactSubCategoriesList$ = this.service.getContactSubCategoriesList();
  }

  addContact() {
    var contact = {
      userId: 1,
      firstName: this.firstName,
      lastName: this.lastName,
      email: this.email,
      categoryId: this.categoryId,
      subCategoryId: this.subCategoryId,
      customSubCategory: this.customSubCategory,
      phoneNumber: this.phoneNumber,
      dateOfBirth: this.dateOfBirth
    }
    this.service.addContact(contact).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById('add-success-alert');
      if (showAddSuccess) {
        showAddSuccess.style.display = "block";
      }
      setTimeout(function () {
        if (showAddSuccess) {
          showAddSuccess.style.display = "none";
        }
      }, 4000);
    })
  }

  updateContact() {
    var contact = {
      id: this.id,
      userId: 1,
      firstName: this.firstName,
      lastName: this.lastName,
      email: this.email,
      categoryId: this.categoryId,
      subCategoryId: this.subCategoryId,
      customSubCategory: this.customSubCategory,
      phoneNumber: this.phoneNumber,
      dateOfBirth: this.dateOfBirth
    }
    var id: number = this.id;
    console.log(id, contact);
    this.service.updateContact(id, contact).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-success-alert');
      if (showUpdateSuccess) {
        showUpdateSuccess.style.display = "block";
      }
      setTimeout(function () {
        if (showUpdateSuccess) {
          showUpdateSuccess.style.display = "none";
        }
      }, 4000);
    })
  }

}
