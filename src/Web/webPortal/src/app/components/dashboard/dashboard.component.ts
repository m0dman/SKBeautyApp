import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NewsletterDialogComponent } from './dialogs/newsletter-dialog/newsletter-dialog.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  imageObject = [{
    image: '../../../assets/images/banner-01.webp',
    thumbImage: '../../../assets/images/banner-01.webp',
  },
  {
    image: '../../../assets/images/banner-02.webp',
    thumbImage: '../../../assets/images/banner-02.webp',
  },
  {
    image: '../../../assets/images/banner-03.webp',
    thumbImage: '../../../assets/images/banner-03.webp',
  },
  {
    image: '../../../assets/images/banner-04.webp',
    thumbImage: '../../../assets/images/banner-04.webp',
  },
  {
    image: '../../../assets/images/banner-05.webp',
    thumbImage: '../../../assets/images/banner-05.webp',
  },
  {
    image: '../../../assets/images/banner-06.webp',
    thumbImage: '../../../assets/images/banner-06.webp',
  }]

  constructor(private dialog: MatDialog) { }

  ngOnInit(): void {
  }

  newsletterSignup()
  {
    const dialogRef = this.dialog.open(NewsletterDialogComponent);
  }
}
