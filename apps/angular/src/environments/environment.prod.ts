import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Thatch',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:7600/',
    redirectUri: baseUrl,
    clientId: 'Thatch_App',
    clientSecret: '1q2w3e*',
    responseType: 'code',
    scope: 'offline_access IdentityService AdministrationService SaasService',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:7500',
      rootNamespace: 'Thatch',
    },
  },
} as Environment;
