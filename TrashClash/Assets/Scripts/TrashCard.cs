using UnityEngine;

namespace CardHouse
{
    public class TrashCard : CardSetup
    {
        public SpriteRenderer Image;
        public SpriteRenderer BackImage;
        public TrashType Kategori { get; private set; }
        public int Cost { get; private set; }
        public int Value { get; private set; }
        public int Penalty { get; private set; }
        public int None { get; private set; }
        public int Debuff { get; private set; }

        public override void Apply(CardDefinition data)
        {
            if (data is CardSO trashCard)
            {
                Image.sprite = trashCard.Art;
                if (trashCard.BackArt != null)
                {
                    BackImage.sprite = trashCard.BackArt;
                }
                Cost = trashCard.Cost;
                Value = trashCard.Value;
                Penalty = trashCard.Penalty;
                Kategori = trashCard.Kategori;
                None = trashCard.None;
                Debuff = trashCard.Debuff;
            }
        }
    }
}
