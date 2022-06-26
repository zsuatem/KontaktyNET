import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor() {
  }

  ngOnInit(): void {
  }

  loginForm = new FormGroup({
    email: new FormControl("", [Validators.required, Validators.email]),
    password: new FormControl("", [Validators.required, Validators.minLength(10), Validators.maxLength(64)])
  })

  loginSubmitted() {
    console.log(this.loginForm.getRawValue());

  }

  get Email(): FormControl {
    return this.loginForm.get("email") as FormControl;
  }

  get Password(): FormControl {
    return this.loginForm.get("password") as FormControl;
  }

  // private http: HttpClient, private router: Router
  // this.http.post('http://localhost:8000/api/login', this.form.getRawValue(), { withCredentials: true })
  // .subscribe(() => this.router.navigate(['/']));
}