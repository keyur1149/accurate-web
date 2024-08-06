import { Injectable } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";

@Injectable({
  providedIn: "root",
})
export class SnackBarService {
  constructor(private _snackBar: MatSnackBar) {}

  Success(message: string, duration: number = 2000) {
    this._snackBar.open(message, "Close", {
      duration: duration,
      panelClass: "snackbar-success",
      horizontalPosition: "end",
      verticalPosition: "top",
    });
  }

  Error(message: string, duration: number = 2000) {
    this._snackBar.open(message, "Close", {
      duration: duration,
      panelClass: "snackbar-error",
      horizontalPosition: "end",
      verticalPosition: "top",
    });
  }

  Info(message: string, duration: number = 2000) {
    this._snackBar.open(message, "Close", {
      duration: duration,
      panelClass: "snackbar-info",
      horizontalPosition: "end",
      verticalPosition: "top",
    });
  }

  Warning(message: string, duration: number = 2000) {
    this._snackBar.open(message, "Close", {
      duration: duration,
      panelClass: "snackbar-warning",
      horizontalPosition: "end",
      verticalPosition: "top",
    });
  }
}