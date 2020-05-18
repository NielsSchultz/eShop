# eShop projekt

## Entity Relation Diagram![E Shop E R D](../../../Desktop/eShopERD.png)

# Kravspecifikation

### Krav til forsiden
- [x] Forsiden viser et antal produkter med et billede af hver, prisen, navn og en knap til at l�gge varen i kurven
- [x] Der benyttes Paging s�ledes at forsiden kun viser et bestemt antal produkter ad gangen. Man kan se at der evt. er flere produkter
- [x] Der er mulighed for at s�ge p� "Brand" og p� "Type" eller lignende
- [x] Der er ogs� fritekst-s�gning
- [ ] Der er mulighed for stigende og faldende sortering
- [x] Der vises et ikon med en varekurv og et antal varer i kurven. Klikkes p� ikonet, vises varekurven
- [x] L�gges en vare i kurven, vises den opdaterede varekurv

### Krav til varekurven
- [x] Varekurven viser en opdateret liste af valgte produkter, med billede, navn, styk-pris, antal (skal kunne �ndres) samt linjepriseen.
- [ ] Der skal v�re en Update knap, som opdaterer priserne hvis man �ndrer antallet.
- [ ] Det skal v�re muligt at fjerne et produkt fra varekurven, hvis man fortryder valget
- [x] Der skal v�re en Checkout knap, som f�rer til Checkout-siden
- [ ] Der skal v�re en knap, der giver mulighed for at forts�tte med at handle, inden man g�r til checkout

### Krav til checkout
- [ ] Brugeren skal afgive oplysninger om email, navn, adresse, valg af betalingsmiddel og forsendelse
- [ ] N�r brugeren trykker p� K�b knappen, skal der udsendes en mail som bekr�ftelse af k�bet

## Optionelle krav
- [ ] Forsiden viser "featured" produkter
- [ ] N�r musen passerer henover et billede af et produkt, fremh�ves billedet (evt. med en skygge eller ramme)
- [ ] Mulighed for at logge ind, f.eks. n�r man g�r til Checkout. 
- [ ] Hvis brugeren er logget ind, slipper brugeren for at registrere sig igen
- [ ] N�r brugeren er logget ind, vises produkter som anses for at v�re interessante for netop denne kunde, baseret p� en profil
- [ ] En Admin side, der giver en administrator en liste over alle produkter og mulighed for at redigere produkterne.

## Andre krav til design og implementation
Designet laves s�ledes at det opfylder best practice indenfor databasedesign
Der benyttes Entity Framework Core
Der foretages en funktionstest, der viser at de funktionelle krav er opfyldt