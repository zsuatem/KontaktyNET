import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ContactApiService } from 'src/app/contact-api.service'

@Component({
  selector: 'app-show-contact',
  templateUrl: './show-contact.component.html',
  styleUrls: ['./show-contact.component.css']
})
export class ShowContactComponent implements OnInit {

  contactList$!: Observable<any[]>;
  contactCategoriesList$!: Observable<any[]>;
  contactCategoriesList: any = [];
  contactSubCategoriesList$!: Observable<any[]>;
  contactSubCategoriesList: any = [];

  // Maps
  contactsCategoriesMap: Map<number, string> = new Map();
  contactsSubCategoriesMap: Map<number, string> = new Map();

  constructor(private service: ContactApiService) { }

  ngOnInit(): void {
    this.contactList$ = this.service.getContactList();
    this.contactCategoriesList$ = this.service.getContactCategoriesList();
    this.refreshContactsCategoriesMap();
    this.contactSubCategoriesList$ = this.service.getContactSubCategoriesList();
    this.refreshContactsSubCategoriesMap();
  }

  modalTitle: string = '';
  activateAddEditContactComponent: boolean = false;
  contact: any;

  modalAdd() {
    this.contact = {
      id: 0,
      userId: null,
      firstName: null,
      lastName: null,
      email: null,
      categoryId: null,
      subCategoryId: null,
      customSubCategory: null,
      phoneNumber: null,
      dateOfBirth: null
    }
    this.modalTitle = "Add Contact";
    this.activateAddEditContactComponent = true;
  }

  modalEdit(item: any) {
    this.contact = item;
    this.modalTitle = "Edit Contact";
    this.activateAddEditContactComponent = true;
  }

  delete(item: any) {
    if (confirm(`Are you want delete it?`)) {
      this.service.deleteContact(item.id).subscribe(res => {

        var showDeleteSuccess = document.getElementById('delete-success-alert');
        if (showDeleteSuccess) {
          showDeleteSuccess.style.display = "block";
        }
        setTimeout(function () {
          if (showDeleteSuccess) {
            showDeleteSuccess.style.display = "none";
          }
        }, 4000);
        this.contactList$ = this.service.getContactList();
      })
    }
  }

  modalClose() {
    this.activateAddEditContactComponent = false;
    this.contactList$ = this.service.getContactList();
  }

  refreshContactsCategoriesMap() {
    this.service.getContactCategoriesList().subscribe(data => {
      this.contactCategoriesList = data;

      for (let i = 0; i < data.length; i++) {
        this.contactsCategoriesMap.set(this.contactCategoriesList[i].id, this.contactCategoriesList[i].categoryName);

      }
    })
  }

  refreshContactsSubCategoriesMap() {
    this.service.getContactSubCategoriesList().subscribe(data => {
      this.contactSubCategoriesList = data;

      for (let i = 0; i < data.length; i++) {
        this.contactsSubCategoriesMap.set(this.contactSubCategoriesList[i].id,
          this.contactSubCategoriesList[i].subCategoryName);

      }
    })
  }

}
