// this checks if the app is running on IE
export const isIE = window.navigator.userAgent.indexOf('MSIE ') > -1 || window.navigator.userAgent.indexOf('Trident/') > -1;

// #endregion

// #region 2) Web API Configuration
/**
 * API config is required
 * */
export const apiConfig: {webApi: string} = {
    webApi: 'http://localhost:5001'
};

// #endregion