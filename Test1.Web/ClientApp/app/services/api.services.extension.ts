import * as generated from "./api.services";

export class ServiceBase {

	protected transformOptions(options: any) {
		console.log("HTTP call, options: " + JSON.stringify(options));
		
		var item = localStorage.getItem('expiration_date');
		if (item) {
			var expirationDate = new Date(item);
			if (expirationDate && expirationDate.getTime() > new Date().getTime()) {
				options.headers.append("Authorization", 'Bearer ' + localStorage.getItem('id_token'));
			}
		}

		return Promise.resolve(options);
	}

	protected transformResult(url: string, response: any, processor: (response: any) => any) {
		if (response.status !== 200 && response.status !== 204) {
			throw new Error(response);
		}
		else {
			return processor(response);
		}
	}
}
