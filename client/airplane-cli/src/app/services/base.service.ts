import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable, of } from 'rxjs';

export abstract class BaseService {
  public Token: string = "";

  constructor() {  }

  protected UrlServiceV1: string = "http://localhost:50763/api/";

  protected serviceError(error: Response | any) {
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(error);
    return Observable.throw(error);
  }

  protected extractData(response: Response) {
    let body = response.json();
    return body.data || {};
  }

}