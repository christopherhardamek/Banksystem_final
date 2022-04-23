using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Banksystem;
public class Bank
{
    List<Account> Accounts;
    IStorageService storageService;
    Bank(IStorageService svc)
    {
        storageService = svc;
        Accounts = storageService.LoadAccounts();
    }
}