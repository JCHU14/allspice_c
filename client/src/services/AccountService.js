import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Recipe } from '../models/Recipe'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getRecipesByAccount() {
    const res = await api.get(`/account/recipes`)
    logger.log('got recipes by id', res.data)
    AppState.recipes = res.data.map((recipe) => new Recipe(recipe))
}
}

export const accountService = new AccountService()
