import { BrowserHistoryBuildOptions, History, createBrowserHistory } from 'history';

let history: History;
let historyOptions: BrowserHistoryBuildOptions = {};

export function getHistory(): History {
    if (!history) {
        history = createBrowserHistory(historyOptions);
    }

    return history;
}
