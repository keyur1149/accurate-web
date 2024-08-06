import { Injectable } from '@angular/core';

@Injectable({
  providedIn: "root",
})
export class LoadingService {
  private isDataLoaded: boolean;
  constructor() {
    this.isDataLoaded = false;
  }

  public showLoader(): void {
    this.isDataLoaded = true;
  }
  public hideLoader(): void {
    this.isDataLoaded = false;
  }
  public getDataStatus(): boolean {
    return this.isDataLoaded;
  }
}