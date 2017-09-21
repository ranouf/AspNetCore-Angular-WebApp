import * as generated from "./api.services";

export class ServiceBase {
	protected transformOptions(options: any) {
		console.log("HTTP call, options: " + JSON.stringify(options));

		options.headers.append("myheader", "myvalue");
		return Promise.resolve(options);
	}

	protected transformResult(url: string, response: any, processor: (response: any) => any) {
		if (response.status !== 200 && response.status !== 204) {
			//TODO Manage Error
		}
		else {
			return processor(response);
		}
	}
}
