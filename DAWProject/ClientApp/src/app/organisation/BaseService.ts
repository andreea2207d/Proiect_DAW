import {HttpClient} from "@angular/common/http";
import {Inject} from "@angular/core";

export class BaseService {
  http: HttpClient;
  constructor(http: HttpClient,
              @Inject('BASE_URL') readonly baseUrl: string) {
    this.http = http;
  }
}
