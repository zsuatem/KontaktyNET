import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  invalidLogin?: boolean;

  constructor(private http: HttpClient, private router: Router) {
  }

  ngOnInit(): void {
  }

  loginForm = new FormGroup({
    email: new FormControl("", [Validators.required, Validators.email]),
    password: new FormControl("", [Validators.required, Validators.minLength(10), Validators.maxLength(64)])
  })

  loginSubmitted() {
    const credentials = {
      'userName': this.loginForm.value.email,
      "password": this.loginForm.value.password

    }

    this.http.post("https://localhost:7251/api/auth/login", credentials)
      .subscribe(res => {
        const token = (<any>Response).token;
        console.log(credentials);
        localStorage.setItem("jwt", token);
        this.invalidLogin = false;
        this.router.navigate(['/']);
      }, err => {
        this.invalidLogin = true;
      })

    console.log(this.loginForm.getRawValue());

  }

  get Email(): FormControl {
    return this.loginForm.get("email") as FormControl;
  }

  get Password(): FormControl {
    return this.loginForm.get("password") as FormControl;
  }
}