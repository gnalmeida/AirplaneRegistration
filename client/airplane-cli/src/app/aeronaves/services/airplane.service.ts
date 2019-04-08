import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from "../../services/base.service";
import { AirplaneViewModel } from "../models/airplaneViewModel";
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class AirplaneService extends BaseService {

  public defaultHeaders = new HttpHeaders();

  constructor(private httpClient: HttpClient) { super(); }

  getAll(): Observable<Array<AirplaneViewModel>> {
    return this.httpClient.get<Array<AirplaneViewModel>>(this.UrlServiceV1 + "airplane");
  }

  get(id: string): Observable<AirplaneViewModel> {
    return this.httpClient.get<AirplaneViewModel>(this.UrlServiceV1 + "airplane/" + id);
  }

  add(airplaneViewModel: AirplaneViewModel): Observable<AirplaneViewModel> {
    airplaneViewModel.id = undefined;

    let response = this.httpClient
      .post<AirplaneViewModel>(this.UrlServiceV1 + "airplane", airplaneViewModel);

    return response;
  };

  update(airplaneViewModel: AirplaneViewModel): Observable<AirplaneViewModel> {
    let response = this.httpClient
      .put<AirplaneViewModel>(this.UrlServiceV1 + "airplane", airplaneViewModel);

    return response;
  };

  delete(id: string): Observable<AirplaneViewModel> {
    let response = this.httpClient
      .delete<AirplaneViewModel>(this.UrlServiceV1 + "airplane/" + id);

    return response;
  };

}