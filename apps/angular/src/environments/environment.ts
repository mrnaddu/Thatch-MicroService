import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Thatch',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:7600/',
    redirectUri: baseUrl,
    clientId: 'Thatch_App',
    responseType: 'code',
    scope: 'IdentityService AdministrationService SaasService',
    requireHttps: false,
  },
  apis: {
    default: {
      url: 'https://localhost:7500',
      rootNamespace: 'Thatch',
    },
  },
} as Environment;
