import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-newsletter-dialog',
  templateUrl: './newsletter-dialog.component.html',
  styleUrls: ['./newsletter-dialog.component.scss']
})

export class NewsletterDialogComponent implements OnInit {
  form: FormGroup;

  constructor(public dialogRef: MatDialogRef<NewsletterDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: string, private router: Router) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      email: new FormControl(this.data, Validators.required),
    });
  }

  get email(): AbstractControl {
    return this.form.get('email');
  }

  closeDialog() {
    this.dialogRef.close();
  }

  subscribe() {
    this.data = this.email.value;
    this.dialogRef.close(this.data);
    this.router.navigate(['/treatment'])
  }
}
